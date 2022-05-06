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

    [SerializeField]
    private GameObject PlayerUpgradePanel;

    [SerializeField]
    private Button PlayerMoneyMultiplierButton;
    [SerializeField]
    private TMP_Text PlayerMoneyMultiplierPriceText;

    [SerializeField]
    private Button PlayerWalkSpeedButton;
    [SerializeField]
    private TMP_Text PlayerWalkSpeedPriceText;

    [SerializeField]
    private Button PlayerWorkSpeedButton;
    [SerializeField]
    private TMP_Text PlayerWorkSpeedPriceText;


    // Employee Menu

    [SerializeField]
    private GameObject EmployeeUpgradePanel;

    [SerializeField]
    private Button EmployeeHireButton;
    [SerializeField]
    private TMP_Text EmployeeHirePriceText;

    [SerializeField]
    private Button EmployeeCollectsMoneyButton;
    [SerializeField]
    private TMP_Text EmployeeCollectsMoneyPriceText;

    [SerializeField]
    private Button EmployeeWorkSpeedButton;
    [SerializeField]
    private TMP_Text EmployeeWorkSpeedPriceText;


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
        PreparePlayerMenu();

        GameManager.Instance.OnMenu = true;

        PlayerUpgradePanel.SetActive(true);
    }

    private void PreparePlayerMenu()
    {
        if (Manager.Instance.PlayerData.PlayerMoneyMultiplierLevel >= 4)
        {
            PlayerMoneyMultiplierButton.interactable = false;
            PlayerMoneyMultiplierPriceText.text = "MAX";
        }
        else
        {
            PlayerMoneyMultiplierPriceText.text = Manager.Instance.Upgrades.PlayerMoneyMultiplier[Manager.Instance.PlayerData.PlayerMoneyMultiplierLevel + 1].Price + "";

            if (Manager.Instance.PlayerData.Money < Manager.Instance.Upgrades.PlayerMoneyMultiplier[Manager.Instance.PlayerData.PlayerMoneyMultiplierLevel + 1].Price)
            {
                PlayerMoneyMultiplierButton.interactable = false;
            }
            else
            {
                PlayerMoneyMultiplierButton.interactable = true;
            }
        }

        if (Manager.Instance.PlayerData.PlayerWalkSpeedLevel >= 4)
        {
            PlayerWalkSpeedButton.interactable = false;
            PlayerWalkSpeedPriceText.text = "MAX";
        }
        else
        {
            PlayerWalkSpeedPriceText.text = Manager.Instance.Upgrades.PlayerWalkSpeed[Manager.Instance.PlayerData.PlayerWalkSpeedLevel + 1].Price + "";

            if (Manager.Instance.PlayerData.Money < Manager.Instance.Upgrades.PlayerWalkSpeed[Manager.Instance.PlayerData.PlayerWalkSpeedLevel + 1].Price)
            {
                PlayerWalkSpeedButton.interactable = false;
            }
            else
            {
                PlayerWalkSpeedButton.interactable = true;
            }
        }

        if (Manager.Instance.PlayerData.PlayerServiceDurationLevel >= 4)
        {
            PlayerWorkSpeedButton.interactable = false;
            PlayerWorkSpeedPriceText.text = "MAX";
        }
        else
        {
            PlayerWorkSpeedPriceText.text = Manager.Instance.Upgrades.PlayerServiceDuration[Manager.Instance.PlayerData.PlayerServiceDurationLevel + 1].Price + "";

            if (Manager.Instance.PlayerData.Money < Manager.Instance.Upgrades.PlayerServiceDuration[Manager.Instance.PlayerData.PlayerServiceDurationLevel + 1].Price)
            {
                PlayerWorkSpeedButton.interactable = false;
            }
            else
            {
                PlayerWorkSpeedButton.interactable = true;
            }
        }
    }

    public void UpgradePlayerMoneyMultiplier()
    {
        Manager.Instance.PlayerData.PlayerMoneyMultiplierLevel++;
        GameManager.Instance.SpentMoney(Manager.Instance.Upgrades.PlayerMoneyMultiplier[Manager.Instance.PlayerData.PlayerMoneyMultiplierLevel].Price);

        GameManager.Instance.SetMoneyMultiplier();

        PreparePlayerMenu();
    }

    public void UpgradePlayerWalkSpeed()
    {
        Manager.Instance.PlayerData.PlayerWalkSpeedLevel++;
        GameManager.Instance.SpentMoney(Manager.Instance.Upgrades.PlayerWalkSpeed[Manager.Instance.PlayerData.PlayerWalkSpeedLevel].Price);

        GameManager.Instance.Player.PlayerController.SetWalkSpeed();

        PreparePlayerMenu();
    }

    public void UpgradePlayerWorkSpeed()
    {
        Manager.Instance.PlayerData.PlayerServiceDurationLevel++;
        GameManager.Instance.SpentMoney(Manager.Instance.Upgrades.PlayerServiceDuration[Manager.Instance.PlayerData.PlayerServiceDurationLevel].Price);

        GameManager.Instance.Player.SetServiceDuration();

        PreparePlayerMenu();
    }

    public void EnableEmployeeMenu()
    {
        PrepareEmployeeMenu();

        GameManager.Instance.OnMenu = true;

        EmployeeUpgradePanel.SetActive(true);
    }

    private void PrepareEmployeeMenu()
    {
        Manager.Instance.PlayerData.CalculateEmployeeCount();

        if (Manager.Instance.PlayerData.GetUnemployedChairs() <= 0)
        {
            EmployeeHireButton.interactable = false;
            EmployeeHirePriceText.text = "MAX";
        }
        else
        {
            EmployeeHirePriceText.text = Manager.Instance.Upgrades.EmployeeHire[Manager.Instance.PlayerData.EmployeeCount] + "";

            if (Manager.Instance.PlayerData.Money < Manager.Instance.Upgrades.EmployeeHire[Manager.Instance.PlayerData.EmployeeCount])
            {
                EmployeeHireButton.interactable = false;
            }
            else
            {
                EmployeeHireButton.interactable = true;
            }
        }

        if (Manager.Instance.PlayerData.EmployeeCollectsMoney == true)
        {
            EmployeeCollectsMoneyButton.interactable = false;
            EmployeeCollectsMoneyPriceText.text = "MAX";
        }
        else
        {
            EmployeeCollectsMoneyPriceText.text = Manager.Instance.Upgrades.EmployeeCollectsMoney.Price + "";

            if (Manager.Instance.PlayerData.Money < Manager.Instance.Upgrades.EmployeeCollectsMoney.Price)
            {
                EmployeeCollectsMoneyButton.interactable = false;
            }
            else
            {
                EmployeeCollectsMoneyButton.interactable = true;
            }
        }

        if (Manager.Instance.PlayerData.EmployeeServiceDurationLevel >= 4)
        {
            EmployeeWorkSpeedButton.interactable = false;
            EmployeeWorkSpeedPriceText.text = "MAX";
        }
        else
        {
            EmployeeWorkSpeedPriceText.text = Manager.Instance.Upgrades.EmployeeServiceDuration[Manager.Instance.PlayerData.EmployeeServiceDurationLevel + 1].Price + "";

            if (Manager.Instance.PlayerData.Money < Manager.Instance.Upgrades.EmployeeServiceDuration[Manager.Instance.PlayerData.EmployeeServiceDurationLevel + 1].Price)
            {
                EmployeeWorkSpeedButton.interactable = false;
            }
            else
            {
                EmployeeWorkSpeedButton.interactable = true;
            }
        }
    }

    public void UpgradeEmployeeCount()
    {
        GameManager.Instance.SpentMoney(Manager.Instance.Upgrades.EmployeeHire[Manager.Instance.PlayerData.EmployeeCount]);
        GameManager.Instance.BoughtEmployee(Manager.Instance.PlayerData.UpgradeUnemployedBarberChair());

        PrepareEmployeeMenu();
    }

    public void UpgradeEmployeeWorkSpeed()
    {
        Manager.Instance.PlayerData.EmployeeServiceDurationLevel++;
        GameManager.Instance.SpentMoney(Manager.Instance.Upgrades.EmployeeServiceDuration[Manager.Instance.PlayerData.EmployeeServiceDurationLevel].Price);

        GameManager.Instance.SetEmployeeServiceDurations();

        PrepareEmployeeMenu();
    }

    public void UpgradeEmployeeCollectsMoney()
    {
        Manager.Instance.PlayerData.EmployeeCollectsMoney = true;
        GameManager.Instance.SpentMoney(Manager.Instance.Upgrades.EmployeeCollectsMoney.Price);

        GameManager.Instance.SetEmployeeCollectsMoney();

        PrepareEmployeeMenu();
    }

    public void DisableMenus()
    {
        PlayerUpgradePanel.SetActive(false);
        EmployeeUpgradePanel.SetActive(false);

        GameManager.Instance.OnMenu = false;
    }
}
