using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Singleton

    public static UIManager Instance;


    // Money Panel

    [SerializeField]
    private TMP_Text MoneyText;


    // Player Menu



    // Employee Menu




    // Unity Functions

    private void Awake()
    {
        Instance = this;

        UpdateMoneyText();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }


    // Methods

    public void UpdateMoneyText()
    {
        MoneyText.text = Manager.Instance.PlayerData.Money + "";
    }

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
