using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private const int BarberChairCount = 12;

    public int Money;

    public int[] BarberChairLevels;

    public int PlayerWalkSpeedLevel;
    public int PlayerServiceDurationLevel;
    public int PlayerMoneyMultiplierLevel;
    public int EmployeeServiceDurationLevel;
    public bool EmployeeCollectsMoney;

    public int EmployeeCount;

    public PlayerData()
    {
        Money = 0;

        BarberChairLevels = new int[BarberChairCount];
        for (int i = 0; i < BarberChairCount; i++)
        {
            BarberChairLevels[i] = 0;
        }

        BarberChairLevels[0] = 1;
        BarberChairLevels[1] = 2;
        BarberChairLevels[2] = 1;

        PlayerWalkSpeedLevel = 0;
        PlayerServiceDurationLevel = 0;
        PlayerMoneyMultiplierLevel = 0;
        EmployeeServiceDurationLevel = 0;
        EmployeeCollectsMoney = false;

        CalculateEmployeeCount();
    }

    public void CalculateEmployeeCount()
    {
        EmployeeCount = 0;

        for (int i = 0; i < BarberChairLevels.Length; i++)
        {
            if (BarberChairLevels[i] == 3) EmployeeCount++;
        }
    }

    public int GetUnemployedChairs()
    {
        int count = 0;

        for (int i = 0; i < BarberChairLevels.Length; i++)
        {
            if (BarberChairLevels[i] == 2)
            {
                count++;
            }
        }

        return count;
    }

    public int UpgradeUnemployedBarberChair()
    {
        int id = -1;

        for (int i = BarberChairLevels.Length - 1; i >= 0; i--)
        {
            if (BarberChairLevels[i] == 2)
            {
                BarberChairLevels[i] = 3;
                id = i;
                break;
            }
        }

        return id;
    }
}
