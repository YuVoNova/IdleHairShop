using UnityEngine;

public class InteractablePlayerMenu : Interactable
{
    protected override void Interacted()
    {
        base.Interacted();

        Debug.Log("Interacted: PlayerMenu");

        UIManager.Instance.EnablePlayerMenu();
    }
}
