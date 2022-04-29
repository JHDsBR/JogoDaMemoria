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

        if(canClickMe)
            img.color = Color.green;
    }


    public void LoadLevel()
    {
        if(!canClickMe)
            return;

        SceneManager.LoadScene(2); // GamePlay
        PlayerPrefs.SetInt("CurrentLevel", myLevelInt);
    }
}
