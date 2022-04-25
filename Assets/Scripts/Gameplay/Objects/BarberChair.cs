using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarberChair : MonoBehaviour
{
    public int ID;

    public Spot ServiceSpot;

    [SerializeField]
    private List<GameObject> Levels;

    //[HideInInspector]
    public int CurrentLevel;

    [SerializeField]
    private GameObject InteractableService;

    [SerializeField]
    private Employee Employee;

    public Transform SittingPoint;


    private void ChangedLevel()
    {
        if (CurrentLevel == 0)
        {

        }
        else if (CurrentLevel == 1)
        {

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
            Levels[level].SetActive(false);
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
        }
        else if (CurrentLevel == 3)
        {
            Employee.ServeCustomer();

            ServiceSpot.OccupiedBy.GetComponent<Customer>().ServiceStarted();
        }
    }

    public void ServiceCompleted()
    {
        ServiceSpot.OccupiedBy.GetComponent<Customer>().ServiceCompleted();

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
