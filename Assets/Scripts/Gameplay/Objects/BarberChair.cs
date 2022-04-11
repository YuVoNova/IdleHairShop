using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarberChair : MonoBehaviour
{
    [SerializeField]
    private Spot ServiceSpot;

    [SerializeField]
    private List<GameObject> Levels;

    [HideInInspector]
    public int CurrentLevel;


}
