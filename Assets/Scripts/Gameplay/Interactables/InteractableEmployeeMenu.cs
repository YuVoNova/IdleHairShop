using UnityEngine;

public class InteractableEmployeeMenu : Interactable
{
    protected override void Interacted()
    {
        base.Interacted();

        UIManager.Instance.EnableEmployeeMenu();
    }
}
