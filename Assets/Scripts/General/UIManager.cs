using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton

    public static UIManager Instance;


    // Player Menu



    // Employee Menu




    // Unity Functions

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


    // Methods

    public void EnablePlayerMenu()
    {
        Debug.Log("Enabled PlayerMenu");

        // TO DO -> Enable PlayerMenu here and disable Player movement.
    }

    public void EnableEmployeeMenu()
    {
        Debug.Log("Enabled EmployeeMenu");

        // TO DO -> Enable EmployeeMenu here and disable Player movement.
    }
}
