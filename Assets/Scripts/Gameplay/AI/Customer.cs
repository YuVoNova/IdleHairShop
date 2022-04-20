using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    [HideInInspector]
    public int ID;

    //[HideInInspector]
    public CustomerStates CurrentState;

    [SerializeField]
    private Spot currentOccupiedSpot;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float StopDistance;

    private Vector3 destinationPoint;

    private void Awake()
    {
        CurrentState = CustomerStates.Walking_Intro;
    }

    private void Update()
    {
        switch (CurrentState)
        {
            case CustomerStates.Walking_Intro:

                if (Vector3.Distance(transform.position, destinationPoint) < StopDistance)
                {
                    if (currentOccupiedSpot.SpotType == SpotTypes.Waiting)
                    {
                        GoToWaitingSpot();
                    }
                    else if (currentOccupiedSpot.SpotType == SpotTypes.Service)
                    {
                        GoToEmptyServiceSeat();
                    }
                }

                break;

            case CustomerStates.Walking_WaitingSpot:

                if (Vector3.Distance(transform.position, destinationPoint) < StopDistance)
                {
                    CurrentState = CustomerStates.Waiting_WaitingSpot;

                    agent.enabled = false;
                    transform.position = destinationPoint;
                    transform.eulerAngles = new Vector3(0f, 135f, 0f);
                }

                break;

            case CustomerStates.Waiting_WaitingSpot:



                break;

            case CustomerStates.Walking_Service:

                if (Vector3.Distance(transform.position, destinationPoint) < StopDistance)
                {
                    // TO DO -> Set customer's position and trigger sitting animation here.

                    agent.enabled = false;
                    transform.position = currentOccupiedSpot.transform.parent.GetComponent<BarberChair>().SittingPoint.position;
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);

                    CurrentState = CustomerStates.Waiting_Service;

                    currentOccupiedSpot.transform.parent.GetComponent<BarberChair>().ReadyForService();
                }

                break;

            case CustomerStates.Waiting_Service:



                break;

            case CustomerStates.Service:

                

                break;

            case CustomerStates.Walking_Outro:

                if (Vector3.Distance(transform.position, destinationPoint) < StopDistance)
                {
                    Destroy(gameObject);
                }

                break;

            default:



                break;
        }
    }

    private void GoToWaitingSpot()
    {
        destinationPoint = currentOccupiedSpot.transform.position;
        agent.SetDestination(destinationPoint);

        CurrentState = CustomerStates.Walking_WaitingSpot;
    }

    private void GoToEmptyServiceSeat()
    {
        destinationPoint = currentOccupiedSpot.transform.position;
        agent.SetDestination(destinationPoint);

        CurrentState = CustomerStates.Walking_Service;
    }

    public void InitiateCustomer(Spot spot)
    {
        currentOccupiedSpot = spot;

        destinationPoint = GameManager.Instance.IntroPoint.position;
        agent.SetDestination(destinationPoint);
    }

    public void SetCustomerForService(Spot spot)
    {
        if (CurrentState == CustomerStates.Waiting_WaitingSpot || CurrentState == CustomerStates.Walking_WaitingSpot)
        {
            GameManager.Instance.LeftWaitingSpot(currentOccupiedSpot);

            if (!agent.enabled)
            {
                agent.enabled = true;
            }
        }

        currentOccupiedSpot = spot;

        GoToEmptyServiceSeat();
    }

    public void ServiceStarted()
    {
        // TO DO -> Trigger animation, VFX, or SFX here (if any).

        CurrentState = CustomerStates.Service;
    }

    public void ServiceCompleted()
    {
        transform.position = currentOccupiedSpot.transform.parent.GetComponent<BarberChair>().ServiceSpot.transform.position;
        agent.enabled = true;

        // TO DO -> Scatter money.
        // TO DO -> Change character.
        // TO DO -> Trigger Walk animation here.

        destinationPoint = GameManager.Instance.OutroPoint.position;
        agent.SetDestination(destinationPoint);

        CurrentState = CustomerStates.Walking_Outro;
    }
}
