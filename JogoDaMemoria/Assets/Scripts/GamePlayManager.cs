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
    public GameObject skipText;

    public GameObject blur, winBack, loseBack;

    public AudioSource flidSound;

    public Text showLevel;

    public static GamePlayManager instance;

    bool skip;

    void Start()
    {
        instance = this;
        // showLevel.text = PlayerPrefs.GetInt("CurrentLevel", 1).ToString();
    }


    public void Win()
    {
        resultText.text = "WIN";
        resultText.color = Color.green;

             buttons.SetActive(false);
                blur.SetActive(false);
             winBack.SetActive(true);
            loseBack.SetActive(false);
        resultScreen.SetActive(true);
          nextButton.SetActive(PlayerPrefs.GetInt("CurrentLevel",1) < 84); // é necessário verificar se é o ultimo nível antes de ativar o botão
    }


    public void Lose()
    {
        StartCoroutine("Lose_");
    }


    IEnumerator Lose_()
    {
        yield return new WaitForSeconds(1.5f);
        CardManager.instance.FaceUpAllCards();
        skipText.SetActive(true);
        buttons.SetActive(false);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        skipText.SetActive(false);
        // yield return new WaitForSeconds(Mathf.Sqrt(CardManager.instance.numberOfCards));
        resultText.text = "LOSE";
        resultText.color = Color.red;

                blur.SetActive(false);
             winBack.SetActive(false);
            loseBack.SetActive(true);
        resultScreen.SetActive(true);
          nextButton.SetActive(PlayerPrefs.GetInt("CurrentLevel",1) < GameDataManager.instance.maxLevel);
    }


    void OnMouseDown()
    {
        skip = true;
    }



}
