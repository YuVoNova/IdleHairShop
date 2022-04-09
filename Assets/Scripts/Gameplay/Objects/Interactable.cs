using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider interactionCollider;

    private float interactionTimer;

    protected virtual void Awake()
    {
        interactionCollider = GetComponent<Collider>();

        interactionTimer = 0f;


    }

    protected virtual void Update()
    {
        if (interactionTimer > 0f)
        {
            interactionTimer -= Time.deltaTime;

            if (interactionTimer <= 0f)
            {
                Interacted();
            }
        }


    }

    public virtual void StartInteraction(float duration)
    {
        interactionTimer = duration;

        Debug.Log("Started Interaction");


    }

    public virtual void ExitInteraction()
    {
        interactionTimer = 0f;

        Debug.Log("Exit Interaction");


    }

    protected virtual void Interacted()
    {
        Debug.Log("Interacted Base");


    }
}
