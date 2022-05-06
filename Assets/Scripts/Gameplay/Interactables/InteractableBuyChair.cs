using UnityEngine;
using TMPro;

public class InteractableBuyChair : Interactable
{
    [SerializeField]
    private TMP_Text PriceText;

    private int price;
    private int payValue;
    private int step;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void ExitPreInteraction()
    {
        base.ExitPreInteraction();

        GameManager.Instance.Player.MoneyFlower.StartFlow(GameManager.Instance.Player.transform, transform);
    }

    public override void ExitInteraction()
    {
        base.ExitInteraction();

        GameManager.Instance.Player.MoneyFlower.EndFlow();
    }

    protected override void ProgressInteraction()
    {
        base.ProgressInteraction();

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
                    GameManager.Instance.Player.MoneyFlower.EndFlow();
                    GameManager.Instance.BoughtBarberChair(transform.parent.parent.parent.GetComponent<BarberChair>().ID);
                }
            }
        }
        else
        {
            GameManager.Instance.Player.MoneyFlower.EndFlow();
        }
    }

    public void Initialize(int price, int step)
    {
        this.price = price;
        this.step = step;

        PriceText.text = price + "";
    }
}
