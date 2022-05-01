using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider interactionCollider;

    [SerializeField]
    private float PreInteractionDuration;

    private bool hasPreInteraction;

    private float interactionTimer;
    private float preInteractionTimer;

    public InteractionTypes InteractionType;

    protected virtual void Awake()
    {
        interactionCollider = GetComponent<Collider>();

        interactionTimer = 0f;
        preInteractionTimer = 0f;

        hasPreInteraction = true;
    }

    protected virtual void Update()
    {
        if (hasPreInteraction)
        {
            if (preInteractionTimer > 0f)
            {
                preInteractionTimer -= Time.deltaTime;

                if (preInteractionTimer <= 0f)
                {
                    hasPreInteraction = false;

                    ExitPreInteraction();
                }
            }
        }
        else
        {
            if (InteractionType == InteractionTypes.OneTime)
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
            else if (InteractionType == InteractionTypes.Progress)
            {
                ProgressInteraction();
            }
        }
    }

    protected virtual void ProgressInteraction()
    {

    }

    public virtual void StartInteraction(float duration)
    {
        interactionTimer = duration;
        preInteractionTimer = PreInteractionDuration;

        hasPreInteraction = true;


    }

    public virtual void ExitPreInteraction()
    {

    }

    public virtual void ExitInteraction()
    {
        interactionTimer = 0f;
        preInteractionTimer = 0f;

        hasPreInteraction = true;


    }

    protected virtual void Interacted()
    {

    }
}
