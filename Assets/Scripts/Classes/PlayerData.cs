using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private const int BarberChairCount = 15;

    public int Money;

    public int[] BarberChairLevels;

    public int PlayerWalkSpeedLevel;
    public int PlayerServiceDurationLevel;
    public int PlayerMoneyMultiplierLevel;
    public int EmployeeServiceDurationLevel;
    public bool EmployeeCollectsMoney;

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
    }
}
