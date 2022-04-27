using UnityEngine;

public class InteractableService : Interactable
{
    [SerializeField]
    private Transform ChairParent;

    protected override void Interacted()
    {
        base.Interacted();

        Debug.Log("Interacted: Service");

        ChairParent.GetComponent<BarberChair>().ServiceCompleted();
    }
}
