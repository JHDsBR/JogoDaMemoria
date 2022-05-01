using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{

    public int maxLevel;
    public int numberOfCardsTurned;
    public int maxLifes;
    public int currentLifes;

    public GameObject[] dontDestory;

    public static GameDataManager instance;


    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        foreach(GameObject obj in dontDestory)
            DontDestroyOnLoad(obj);

        LoadData();
    }


    public void SaveData()
    {
        SaveAndLoad.SaveGame(this);
    }


    public void LoadData()
    {
        GameData data = SaveAndLoad.LoadGame();

        if(data==null)
        {
            print("era null");
            data = new GameData(this);
        }
        // print(data);

        // return;
        // maxLevel = 84;
        maxLevel = data.maxLevel;
        numberOfCardsTurned = data.numberOfCardsTurned;
        // maxLifes = data.maxLifes;
        // maxLifes = 5;
        // currentLifes = 5;
    }

}
