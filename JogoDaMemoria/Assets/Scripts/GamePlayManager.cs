using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GamePlayManager : MonoBehaviour
{

    public GameObject resultScreen;
    public GameObject nextButton;
    public Text resultText;
    public GameObject buttons;

    public GameObject blur, winBack, loseBack;

    public AudioSource flidSound;

    public Text showLevel;

    public static GamePlayManager instance;


    void Start()
    {
        instance = this;
        // showLevel.text = PlayerPrefs.GetInt("CurrentLevel", 1).ToString();
    }


    public void Win()
    {
        //0069FF
        //313131
        resultText.text = "WIN";
        resultText.color = Color.green;
        buttons.SetActive(false);
        blur.SetActive(false);
        winBack.SetActive(true);
        loseBack.SetActive(false);
        resultScreen.SetActive(true);
        nextButton.SetActive(true);
    }


    public void Lose()
    {
        resultText.text = "LOSE";
        resultText.color = Color.red;
        blur.SetActive(false);
        winBack.SetActive(false);
        loseBack.SetActive(true);
        buttons.SetActive(false);
        resultScreen.SetActive(true);
        nextButton.SetActive(false);
    }

}
