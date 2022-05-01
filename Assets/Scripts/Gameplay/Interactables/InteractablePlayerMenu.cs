using UnityEngine;

public class InteractablePlayerMenu : Interactable
{
    protected override void Interacted()
    {
        base.Interacted();

        UIManager.Instance.EnablePlayerMenu();
    }
}
