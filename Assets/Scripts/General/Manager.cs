using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using GameAnalyticsSDK;
//using Facebook.Unity;

public class Manager : MonoBehaviour
{
    // Singleton

    private static Manager instance;
    public static Manager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("Manager").GetComponent<Manager>();
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }


    // Player

    [HideInInspector]
    public PlayerData PlayerData;


    // Game Data



    // Levels



    // Data Handling

    private JsonData jsonData;
    private string dataPath;


    // Unity Functions

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationPause(bool pause)
    {
        /*
        if (!pause)
        {
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
            }
            else
            {
                FB.Init(() => { FB.ActivateApp(); });
            }
        }
        */
    }


    // Functions

    private void Initialize()
    {
        InitializeSDK();

        InitializePlayerData();

        // TO DO -> Initialize other data here.
    }

    private void InitializeSDK()
    {
        /*
        GameAnalytics.Initialize();

        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            FB.Init(() => { FB.ActivateApp(); });
        }
        */
    }

    private void InitializeUpgrades()
    {
        // TO DO -> Initialize PlayerData here.
    }

    public void Save()
    {
        SerializeData();
    }



    #region Data Handling

    private void InitializePlayerData()
    {
        PlayerData = new PlayerData();
        jsonData = new JsonData();

        dataPath = Path.Combine(Application.persistentDataPath, "HyperSurvivorSave.json");

        if (File.Exists(dataPath))
        {
            DeserializeData();
        }
        else
        {
            PlayerData.Money = 0;

            File.Create(dataPath).Close();

            SerializeData();
        }
    }

    // Saves progress data.
    private void SerializeData()
    {
        jsonData.Money = PlayerData.Money;

        string jsonDataString = JsonUtility.ToJson(jsonData, true);

        File.WriteAllText(dataPath, jsonDataString);
    }

    // Loads progress data.
    private void DeserializeData()
    {
        string jsonDataString = File.ReadAllText(dataPath);

        jsonData = JsonUtility.FromJson<JsonData>(jsonDataString);

        PlayerData.Money = jsonData.Money;
    }

    #endregion
}

public class JsonData
{
    public int Money;

    public JsonData()
    {
        Money = 0;
    }
}
