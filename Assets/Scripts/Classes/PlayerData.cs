using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int Money;

    public List<int> BarberChairLevels;

    public PlayerData()
    {
        Money = 0;

        BarberChairLevels = new List<int>();
    }
}
