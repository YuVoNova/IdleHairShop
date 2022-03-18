using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton

    public static GameManager Instance;


    // Values

    public bool IsGameOn;


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

    private void StartGame()
    {
        IsGameOn = true;

        // TEST
        


        // TEST
    }
}
