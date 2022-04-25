using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    // Singleton

    public static GameManager Instance;


    // Objects & Components

    [SerializeField]
    private Player Player;

    [SerializeField]
    private NavMeshSurface NavMeshSurface;

    [SerializeField]
    private Transform SpawnPoint;

    public Transform IntroPoint;
    public Transform OutroPoint;

    [SerializeField]
    private Transform BarberChairsTransform;
    private List<BarberChair> BarberChairs;

    [SerializeField]
    private List<Spot> WaitingSpots;

    private List<int> EmptyWaitingSpots;
    private List<int> OccupiedWaitingSpots;

    private List<int> EmptyServiceSeats;
    private List<int> OccupiedServiceSeats;

    private List<Customer> Customers;

    [SerializeField]
    private GameObject CustomerPrefab;
    [SerializeField]
    private Transform CustomersParent;


    // Values

    private int activeSpotCount;

    [SerializeField]
    private float customerSpawnDuration;
    private float customerSpawnTimer;

    private int customerID;

    [HideInInspector]
    public Vector3 PlayerPosition;
    [HideInInspector]
    public bool IsGameOn;


    // Unity Functions

    private void Awake()
    {
        Instance = this;

        EmptyWaitingSpots = new List<int>();
        for (int i = 0; i < WaitingSpots.Count; i++)
        {
            EmptyWaitingSpots.Add(i);
        }
        OccupiedWaitingSpots = new List<int>();

        InitializeBarberChairs();

        NavMeshSurface.BuildNavMesh();

        Customers = new List<Customer>();

        activeSpotCount = WaitingSpots.Count + BarberChairs.Count;

        customerSpawnTimer = 0f;

        customerID = 0;
    }

    private void Start()
    {
        // TEST

        StartGame();

        // TEST
    }

    private void Update()
    {
        if (IsGameOn)
        {
            if (customerSpawnTimer <= 0f)
            {
                if (!(EmptyServiceSeats.Count == 0 && EmptyWaitingSpots.Count == 0) && Customers.Count < activeSpotCount)
                {
                    SpawnCustomer();

                    customerSpawnTimer = customerSpawnDuration;
                }
            }
            else
            {
                customerSpawnTimer -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        PlayerPosition = Player.transform.position;
    }




    // Methods

    private void InitializeBarberChairs()
    {
        BarberChairs = new List<BarberChair>();
        foreach (Transform child in BarberChairsTransform)
        {
            BarberChairs.Add(child.GetComponent<BarberChair>());
        }

        EmptyServiceSeats = new List<int>();
        for (int i = 0; i < BarberChairs.Count; i++)
        {
            BarberChairs[i].InitializeBarberChair(Manager.Instance.PlayerData.BarberChairLevels[i]);

            if (BarberChairs[i].CurrentLevel > 1)
            {
                EmptyServiceSeats.Add(i);
            }
        }
        OccupiedServiceSeats = new List<int>();
    }

    private void StartGame()
    {
        IsGameOn = true;

        // TEST



        // TEST
    }

    private void SpawnCustomer()
    {
        Customer spawnedCustomer = Instantiate(CustomerPrefab, SpawnPoint.position, Quaternion.identity, CustomersParent).GetComponent<Customer>();
        spawnedCustomer.ID = customerID;
        customerID++;
        Customers.Add(spawnedCustomer.GetComponent<Customer>());

        int id;
        if (EmptyServiceSeats.Count > 0)
        {
            id = EmptyServiceSeats[Mathf.FloorToInt(Random.Range(0f, EmptyServiceSeats.Count))];

            EmptyServiceSeats.Remove(id);
            OccupiedServiceSeats.Add(id);

            BarberChairs[id].ServiceSpot.OccupiedBy = spawnedCustomer.gameObject;
            spawnedCustomer.InitiateCustomer(BarberChairs[id].ServiceSpot);
        }
        else
        {
            if (EmptyWaitingSpots.Count > 0)
            {
                id = EmptyWaitingSpots[Mathf.FloorToInt(Random.Range(0f, EmptyWaitingSpots.Count))];

                EmptyWaitingSpots.Remove(id);
                OccupiedWaitingSpots.Add(id);

                WaitingSpots[id].OccupiedBy = spawnedCustomer.gameObject;
                spawnedCustomer.InitiateCustomer(WaitingSpots[id]);
            }
            else
            {
                // ERROR
                Debug.LogError("ERROR: No spots are empty but Customer is spawned.");
            }
        }
    }

    public void LeftWaitingSpot(Spot spot)
    {
        int id = int.Parse(spot.transform.name.Split('_')[1]);

        if (OccupiedWaitingSpots.Contains(id))
        {
            OccupiedWaitingSpots.Remove(id);
            EmptyWaitingSpots.Add(id);

            WaitingSpots[id].OccupiedBy = null;
        }
        else
        {
            // ERROR
            Debug.LogError("ERROR: No such occupied WaitingSpot was found.");
        }
    }

    public void LeftServiceSeat(int id)
    {
        if (OccupiedServiceSeats.Contains(id))
        {
            if (Customers.Contains(BarberChairs[id].ServiceSpot.OccupiedBy.GetComponent<Customer>()))
            {
                Customers.Remove(BarberChairs[id].ServiceSpot.OccupiedBy.GetComponent<Customer>());
            }

            OccupiedServiceSeats.Remove(id);
            EmptyServiceSeats.Add(id);

            BarberChairs[id].ServiceSpot.OccupiedBy = null;

            if (OccupiedWaitingSpots.Count > 0)
            {
                EmptyServiceSeats.Remove(id);
                OccupiedServiceSeats.Add(id);

                int sendCustomerID = Customers.IndexOf(WaitingSpots[OccupiedWaitingSpots[0]].OccupiedBy.GetComponent<Customer>());

                BarberChairs[id].ServiceSpot.OccupiedBy = Customers[sendCustomerID].gameObject;

                Customers[sendCustomerID].SetCustomerForService(BarberChairs[id].ServiceSpot);
            }
        }
        else
        {
            // ERROR
            Debug.LogError("ERROR: No such occupied BarberChair was found.");
        }
    }
}
