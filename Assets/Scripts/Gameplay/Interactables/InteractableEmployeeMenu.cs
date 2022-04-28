using UnityEngine;

public class InteractableEmployeeMenu : Interactable
{
    protected override void Interacted()
    {
        base.Interacted();

        Debug.Log("Interacted: EmployeeMenu");

        UIManager.Instance.EnableEmployeeMenu();
    }
}
