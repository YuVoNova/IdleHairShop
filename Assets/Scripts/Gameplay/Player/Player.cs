using UnityEngine;

public class Player : MonoBehaviour
{
    // Objects & Components

    [SerializeField]
    private PlayerController PlayerController;


    // Values

    [SerializeField]
    private float InteractionDuration;

    private float ServiceDuration;


    // Unity Functions

    private void Awake()
    {
        SetServiceDuration();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)    // Collectible
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)        // Interactable
        {
            other.GetComponent<Interactable>().StartInteraction(InteractionDuration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)        // Interactable
        {
            other.GetComponent<Interactable>().ExitInteraction();
        }
    }


    // Methods

    public void SetServiceDuration()
    {
        ServiceDuration = Manager.Instance.Upgrades.PlayerServiceDuration[Manager.Instance.PlayerData.PlayerServiceDurationLevel].Value;
    }

    public void LeveledUpPlayerWalkSpeed()
    {
        PlayerController.SetWalkSpeed();
    }
}
