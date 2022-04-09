using UnityEngine;

public class Player : MonoBehaviour
{
    // Objects & Components




    // Values

    [SerializeField]
    private float InteractionDuration;



    // Unity Functions

    private void Awake()
    {
        
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
        if (other.gameObject.layer == 8)    // Interactable
        {
            other.GetComponent<Interactable>().StartInteraction(InteractionDuration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)    // Interactable
        {
            other.GetComponent<Interactable>().ExitInteraction();
        }
    }


    // Methods


}
