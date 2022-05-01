using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider interactionCollider;

    private float currentDuration;

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

                    GameManager.Instance.Player.InteractionFiller.fillAmount = 1f - (interactionTimer / currentDuration);

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
        currentDuration = duration;
        interactionTimer = duration;
        preInteractionTimer = PreInteractionDuration;

        hasPreInteraction = true;

        GameManager.Instance.Player.InteractionFiller.fillAmount = 0f;
    }

    public virtual void ExitPreInteraction()
    {
        GameManager.Instance.Player.InteractionFiller.fillAmount = 0f;
    }

    public virtual void ExitInteraction()
    {
        interactionTimer = 0f;
        preInteractionTimer = 0f;

        hasPreInteraction = true;

        GameManager.Instance.Player.InteractionFiller.fillAmount = 0f;
    }

    protected virtual void Interacted()
    {
        GameManager.Instance.Player.InteractionFiller.fillAmount = 0f;
    }
}
