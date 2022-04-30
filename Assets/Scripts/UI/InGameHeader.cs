using UnityEngine;

public class InGameHeader : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
