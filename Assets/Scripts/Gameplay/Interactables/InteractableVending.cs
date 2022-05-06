using UnityEngine;
using TMPro;

public class InteractableVending : Interactable
{
    [SerializeField]
    private TMP_Text AmountText;

    [SerializeField]
    private int AmountLimit;
    private int currentAmount;

    [SerializeField]
    private int Step;
    private int payValue;

    [SerializeField]
    private float TickAmount;
    private float timer;

    [SerializeField]
    private float PayDuration;
    private float payTimer;

    private bool isInteracting;

    protected override void Awake()
    {
        base.Awake();

        currentAmount = 0;
        timer = 0f;
        payTimer = 0f;

        isInteracting = false;
    }

    protected override void Update()
    {
        base.Update();

        if (!isInteracting)
        {
            if (currentAmount < AmountLimit)
            {
                if (timer <= 0f)
                {
                    currentAmount = Mathf.FloorToInt(Mathf.Clamp(currentAmount + 1, 0f, AmountLimit));

                    UpdateText();

                    timer = TickAmount;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
    }

    protected override void ProgressInteraction()
    {
        base.ProgressInteraction();

        if (isInteracting)
        {
            if (payTimer <= 0f)
            {
                if (currentAmount > 0)
                {
                    if (Step > currentAmount)
                    {
                        payValue = currentAmount;
                    }
                    else
                    {
                        payValue = Step;
                    }

                    currentAmount -= payValue;
                    UpdateText();

                    GameManager.Instance.MoneyEarned(payValue);

                    if (currentAmount == 0)
                    {
                        GameManager.Instance.Player.MoneyFlower.EndFlow();
                        isInteracting = false;
                    }
                }
                else
                {
                    GameManager.Instance.Player.MoneyFlower.EndFlow();
                    isInteracting = false;
                }

                payTimer = PayDuration;
            }
            else
            {
                payTimer -= Time.deltaTime;
            }
        }
    }

    public override void ExitPreInteraction()
    {
        base.ExitPreInteraction();

        GameManager.Instance.Player.MoneyFlower.StartFlow(transform, GameManager.Instance.Player.transform);
        isInteracting = true;
    }

    public override void ExitInteraction()
    {
        base.ExitInteraction();

        isInteracting = false;
    }

    private void UpdateText()
    {
        AmountText.text = currentAmount + "/" + AmountLimit;
    }
}
