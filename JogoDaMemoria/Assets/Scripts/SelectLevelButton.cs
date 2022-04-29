using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelButton : MonoBehaviour
{

    public Text text;
    public int myLevelInt;


    public void LoadLevel()
    {
        SceneManager.LoadScene(1); // GamePlay
        PlayerPrefs.SetInt("CurrentLevel", myLevelInt);
    }
}
