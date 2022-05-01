using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    void Start()
    {
        GameDataManager.instance.SaveData();
    }

    public void LoadNextLevel() // pode ser usado para chamar proximo nivel
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        // PlayerPrefs.SetInt("CurrentLevel", currentLevel+1);
        LoadScene.instance.LoadLevel(currentLevel+1);
    }

    public void LoadLastLevel() // pode ser usado para chamar proximo nivel
    {
        LoadScene.instance.LoadLastLevel();
    }


    public void ReplayLastLevelPlayied()
    {
        LoadScene.instance.ReplayLastLevelPlayied();
    }


    public void GoMenu()
    {
        LoadScene.instance.Load(1);
    }
}
