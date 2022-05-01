using UnityEngine;

public class InteractableService : Interactable
{
    [SerializeField]
    private Transform ChairParent;

    public override void ExitPreInteraction()
    {
        base.ExitPreInteraction();

        GameManager.Instance.Player.Animate("isWorking", true);

        GameManager.Instance.Player.AudioSource.volume = 0.05f;
        GameManager.Instance.Player.AudioSource.clip = Manager.Instance.Audios["Scissors"];
        GameManager.Instance.Player.AudioSource.loop = true;
        GameManager.Instance.Player.AudioSource.Play();
    }

    public override void ExitInteraction()
    {
        base.ExitInteraction();

        GameManager.Instance.Player.Animate("isWorking", false);

        StopSound();
    }

    protected override void Interacted()
    {
        base.Interacted();

        GameManager.Instance.Player.Animate("isWorking", false);

        ChairParent.GetComponent<BarberChair>().ServiceCompleted();

        GameManager.Instance.Player.IsServing = false;

        StopSound();
    }

    private void StopSound()
    {
        GameManager.Instance.Player.AudioSource.loop = false;
        GameManager.Instance.Player.AudioSource.Stop();
    }
}
