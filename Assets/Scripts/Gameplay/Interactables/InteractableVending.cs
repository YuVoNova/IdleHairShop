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
    private float TickAmount;
    private float timer;

    protected override void Awake()
    {
        base.Awake();

        currentAmount = 0;
        timer = 0f;
    }

    protected override void Update()
    {
        base.Update();

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

    protected override void Interacted()
    {
        base.Interacted();

        // TO DO -> Scatter the amount here.

        currentAmount = 0;
        timer = TickAmount;

        UpdateText();
    }

    private void UpdateText()
    {
        AmountText.text = currentAmount + "/" + AmountLimit;
    }
}
