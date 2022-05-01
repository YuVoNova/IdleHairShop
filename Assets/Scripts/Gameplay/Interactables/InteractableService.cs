using UnityEngine;

public class InteractableService : Interactable
{
    [SerializeField]
    private Transform ChairParent;

    public override void ExitPreInteraction()
    {
        base.ExitPreInteraction();

        GameManager.Instance.Player.Animate("isWorking", true);
    }

    public override void ExitInteraction()
    {
        base.ExitInteraction();

        GameManager.Instance.Player.Animate("isWorking", false);
    }

    protected override void Interacted()
    {
        base.Interacted();

        GameManager.Instance.Player.Animate("isWorking", false);

        ChairParent.GetComponent<BarberChair>().ServiceCompleted();

        GameManager.Instance.Player.IsServing = false;
    }
}
