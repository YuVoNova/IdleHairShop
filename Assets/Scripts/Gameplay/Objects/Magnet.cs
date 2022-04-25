using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            // TO DO -> Magnetize the collectible to parent transform.
        }
    }
}
