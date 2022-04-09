using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{
    protected override void Interacted()
    {
        base.Interacted();

        Debug.Log("Interacted Test");
    }
}
