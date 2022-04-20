using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{
    [SerializeField]
    private BarberChair EmployedChair;

    [SerializeField]
    private float ServiceDuration;

    private float serviceTimer;

    private bool isServiceOn;

    private void Awake()
    {
        serviceTimer = 0f;

        isServiceOn = false;
    }

    private void Update()
    {
        if (isServiceOn)
        {
            if (serviceTimer <= 0f)
            {
                EmployedChair.ServiceCompleted();

                isServiceOn = false;
            }
            else
            {
                serviceTimer -= Time.deltaTime;
            }
        }
    }

    public void ServeCustomer()
    {
        // TO DO -> Trigger Employee animation, VFX, and SFX here.

        serviceTimer = ServiceDuration;

        isServiceOn = true;
    }


}
