using UnityEngine;

public class Player : MonoBehaviour
{
    // Objects & Components




    // Values




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
            // TO DO -> Interact here.
        }
    }


    // Methods


}
