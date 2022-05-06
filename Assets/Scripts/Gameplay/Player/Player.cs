using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Objects & Components

    public PlayerController PlayerController;

    public MoneyFlower MoneyFlower;

    [SerializeField]
    private Animator Animator;

    public AudioSource AudioSource;

    public GameObject PlayerCanvas;
    public Image InteractionFiller;


    // Values

    private float ServiceDuration;

    [HideInInspector]
    public bool IsServing;


    // Unity Functions

    private void Awake()
    {
        SetServiceDuration();

        IsServing = false;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)        // Interactable
        {
            if (other.transform.name == "InteractableService")
            {
                if (!IsServing)
                {
                    other.GetComponent<Interactable>().StartInteraction(ServiceDuration);

                    IsServing = true;
                }
            }
            else
            {
                other.GetComponent<Interactable>().StartInteraction(0f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)        // Interactable
        {
            other.GetComponent<Interactable>().ExitInteraction();

            if (IsServing)
            {
                IsServing = false;
            }
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

    public void Animate(string name, bool set)
    {
        Animator.SetBool(name, set);
    }
}
