using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{

    public int maxLevel;
    public int numberOfCardsTurned;

    public static GameDataManager instance;


    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
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
        maxLevel = data.maxLevel;
        numberOfCardsTurned = data.numberOfCardsTurned;
    }

}
