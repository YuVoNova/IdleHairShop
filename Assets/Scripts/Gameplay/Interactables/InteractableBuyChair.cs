using UnityEngine;
using TMPro;

public class InteractableBuyChair : Interactable
{
    [SerializeField]
    private float Duration;

    [SerializeField]
    private TMP_Text PriceText;

    private int price;
    private int step;

    private float timer;

    protected override void Awake()
    {
        base.Awake();

        timer = 0f;
    }

    protected override void ProgressInteraction()
    {
        base.ProgressInteraction();

        if (timer <= 0f)
        {
            if (price != 0)
            {
                price = Mathf.FloorToInt(Mathf.Clamp(price - step, 0f, float.MaxValue));
                PriceText.text = price + "";

                if (price == 0)
                {
                    Debug.Log("Progress Completed");
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void Initialize(int price, int step)
    {
        this.price = price;
        this.step = step;

        PriceText.text = price + "";
    }
}
