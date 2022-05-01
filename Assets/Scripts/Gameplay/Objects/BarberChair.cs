using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarberChair : MonoBehaviour
{
    public int ID;

    [SerializeField]
    private int Price;
    [SerializeField]
    private int PriceStep;

    public Spot ServiceSpot;

    [SerializeField]
    private List<GameObject> Levels;

    [HideInInspector]
    public int CurrentLevel;

    [SerializeField]
    private GameObject InteractableService;

    [SerializeField]
    private GameObject CustomerReadyHeader;

    [SerializeField]
    private InteractableBuyChair InteractableBuyChair;

    [SerializeField]
    private Employee Employee;

    [SerializeField]
    private AudioSource AudioSource;

    public Transform SittingPoint;


    private void ChangedLevel()
    {
        if (CurrentLevel == 0)
        {

        }
        else if (CurrentLevel == 1)
        {
            InteractableBuyChair.Initialize(Price, PriceStep);
        }
        else if (CurrentLevel == 2)
        {

        }
        else if (CurrentLevel == 3)
        {

        }
    }

    public void InitializeBarberChair(int level)
    {
        if (level != 0)
        {
            Levels[CurrentLevel].SetActive(false);
        }

        CurrentLevel = level;
        Levels[CurrentLevel].SetActive(true);

        ChangedLevel();
    }

    public void ReadyForService()
    {
        if (CurrentLevel == 2)
        {
            InteractableService.SetActive(true);
            CustomerReadyHeader.SetActive(true);
        }
        else if (CurrentLevel == 3)
        {
            Employee.ServeCustomer();

            ServiceSpot.OccupiedBy.GetComponent<Customer>().ServiceStarted();
        }
    }

    public void ServiceCompleted()
    {
        if (CurrentLevel == 2)
        {
            InteractableService.SetActive(false);
            CustomerReadyHeader.SetActive(false);
        }

        GetComponent<MoneySpawner>().SpawnMoney(GameManager.Instance.CustomerYieldAmount);

        ServiceSpot.OccupiedBy.GetComponent<Customer>().ServiceCompleted();

        AudioSource.Play();

        GameManager.Instance.LeftServiceSeat(ID);
    }

    public void LeveledUpEmployeeServiceDuration()
    {
        Employee.SetDuration();
    }

    public void UnlockedEmployeeCollectsMoney()
    {
        Employee.CollectMoneyEnabled();
    }
}

/*
    Level 0: Locked behind a Line Paywall.
    Level 1: Can be purchased.
    Level 2: Ready for service by Player.
    Level 3: Ready for service by Employee.
*/
