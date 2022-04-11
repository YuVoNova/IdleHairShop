using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton

    public static GameManager Instance;


    // Objects & Components

    [SerializeField]
    private Player Player;

    private GameObject[] BarberChairs;

    [SerializeField]
    private List<Spot> EmptyWaitingSpots;
    private List<Spot> OccupiedWaitingSpots;

    [SerializeField]
    private List<Spot> EmptyServiceSeats;
    private List<Spot> OccupiedServiceSeats;

    private List<Customer> Customers;
    

    // Values



    [HideInInspector]
    public Vector3 PlayerPosition;
    [HideInInspector]
    public bool IsGameOn;


    // Unity Functions

    private void Awake()
    {
        Instance = this;

        BarberChairs = GameObject.FindGameObjectsWithTag("BarberChair");

        // TO DO -> Take CustomerSeats from PlayerData and initialize accordingly.


    }

    private void Start()
    {
        // TEST

        StartGame();

        // TEST
    }

    private void FixedUpdate()
    {
        PlayerPosition = Player.transform.position;
    }




    // Methods

    private void StartGame()
    {
        IsGameOn = true;

        // TEST



        // TEST
    }
}
