using UnityEngine;

public class Spot : MonoBehaviour
{
    [HideInInspector]
    public bool IsOccupied;

    [HideInInspector]
    public GameObject OccupiedBy;

    public SpotTypes SpotType;


}
