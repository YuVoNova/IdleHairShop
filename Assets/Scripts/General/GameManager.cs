using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton

    public static GameManager Instance;


    // Objects & Components

    [SerializeField]
    private Player Player;


    // Values



    [HideInInspector]
    public Vector3 PlayerPosition;
    [HideInInspector]
    public bool IsGameOn;


    // Unity Functions

    private void Awake()
    {
        Instance = this;


    }

    private void Start()
    {
        // TEST

        StartGame();

        // TEST
    }

    private void FixedUpdate()
    {
        PlayerPosition = Player.transform.position;
    }




    // Methods

    private void StartGame()
    {
        IsGameOn = true;

        // TEST



        // TEST
    }
}
