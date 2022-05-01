using UnityEngine;
using TMPro;

public class InteractableBuyChair : Interactable
{
    [SerializeField]
    private float Duration;

    [SerializeField]
    private TMP_Text PriceText;

    private int price;
    private int payValue;
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
            if (Manager.Instance.PlayerData.Money > 0)
            {
                if (price != 0)
                {
                    if (Manager.Instance.PlayerData.Money >= step)
                    {
                        payValue = Mathf.FloorToInt(Mathf.Clamp(step, 0f, price));
                    }
                    else
                    {
                        if (Manager.Instance.PlayerData.Money >= price)
                        {
                            payValue = price;
                        }
                        else
                        {
                            payValue = Manager.Instance.PlayerData.Money;
                        }
                    }

                    price = Mathf.FloorToInt(Mathf.Clamp(price - payValue, 0f, float.MaxValue));
                    PriceText.text = price + "";

                    GameManager.Instance.SpentMoney(payValue);

                    if (price == 0)
                    {
                        GameManager.Instance.BoughtBarberChair(transform.parent.parent.parent.GetComponent<BarberChair>().ID);
                    }
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
