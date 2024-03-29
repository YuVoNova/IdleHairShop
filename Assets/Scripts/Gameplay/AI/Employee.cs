using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{
    [SerializeField]
    private AudioSource AudioSource;

    [SerializeField]
    private BarberChair EmployedChair;

    [SerializeField]
    private Transform ModelTransform;

    [SerializeField]
    private GameObject MagnetArea;

    private float ServiceDuration;

    //----------- Ogulcan Animator Denemesi ---------------

    [SerializeField]
    private Animator employeeAnimator;

    //----------- Ogulcan Animator Denemesi ---------------

    private float serviceTimer;

    private bool isServiceOn;
    private bool canCollectMoney;

    private void Awake()
    {
        SetDuration();

        serviceTimer = 0f;

        isServiceOn = false;

        canCollectMoney = Manager.Instance.PlayerData.EmployeeCollectsMoney;
        if (canCollectMoney)
        {
            MagnetArea.SetActive(true);
        }
        else
        {
            MagnetArea.SetActive(false);
        }
    }

    private void Update()
    {
        if (isServiceOn)
        {
            if (serviceTimer <= 0f)
            {
                EmployedChair.ServiceCompleted();

                //----------- Ogulcan Animator Denemesi ---------------

                employeeAnimator.SetBool("isWorking", false);

                //----------- Ogulcan Animator Denemesi ---------------

                ModelTransform.localEulerAngles = new Vector3(0f, 180f, 0f);

                AudioSource.Stop();

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

        //----------- Ogulcan Animator Denemesi ---------------

        employeeAnimator.SetBool("isWorking", true);

        //----------- Ogulcan Animator Denemesi ---------------

        ModelTransform.localEulerAngles = new Vector3(0f, -90f, 0f);

        serviceTimer = ServiceDuration;

        AudioSource.Play();

        isServiceOn = true;
    }

    public void SetDuration()
    {
        ServiceDuration = Manager.Instance.Upgrades.EmployeeServiceDuration[Manager.Instance.PlayerData.EmployeeServiceDurationLevel].Value;
    }

    public void CollectMoneyEnabled()
    {
        canCollectMoney = true;
        MagnetArea.SetActive(true);
    }
}
