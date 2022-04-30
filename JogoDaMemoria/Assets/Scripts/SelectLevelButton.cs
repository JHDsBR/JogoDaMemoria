using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelButton : MonoBehaviour
{

    public Text text;
    public int myLevelInt;
    public Image img;

    private bool canClickMe;


    void Start()
    {
        canClickMe = GameDataManager.instance.maxLevel >= myLevelInt;
        // canClickMe=true;
        if(canClickMe)
            img.color = Color.green;
    }


    public void LoadLevel()
    {
        if(!canClickMe)
            return;

        // GameDataManager.instance.maxLifes = 1 + (int)(Mathf.Floor(PlayerPrefs.GetInt("CurrentLevel", 1)/3));
        // GameDataManager.instance.currentLifes = GameDataManager.instance.maxLifes;

        LoadScene.instance.LoadLevel(myLevelInt);
    }
}
