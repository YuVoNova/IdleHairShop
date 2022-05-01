using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrades", menuName = "Upgrades")]
public class Upgrades : ScriptableObject
{
    public List<Upgrade> PlayerWalkSpeed;
    public List<Upgrade> PlayerServiceDuration;
    public List<Upgrade> PlayerMoneyMultiplier;
    public List<Upgrade> EmployeeServiceDuration;
    public Upgrade EmployeeCollectsMoney;

    public List<int> EmployeeHire;

    [System.Serializable]
    public class Upgrade
    {
        public float Value;
        public int Price;
    }
}
