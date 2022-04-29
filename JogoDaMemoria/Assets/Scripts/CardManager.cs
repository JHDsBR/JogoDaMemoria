using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CardManager : MonoBehaviour
{
    public int numberOfCards=18;
    public GameObject cardModel;
    public string sheetname;
    public GameObject cardGrid;

    private List<Sprite> sprites;
    private SpriteRenderer sr;
    private string[] names;

    private List<GameObject> lastTwoCardFaceUp = new List<GameObject>();
    private List<GameObject> allCardFaceUp = new List<GameObject>();


    public bool canFlip=true;

    void Start ()
    {
        CreateCards();
        StartCoroutine(CompareCards());
        print($"Level {PlayerPrefs.GetInt("CurrentLevel", 1)}");
    }


    IEnumerator CompareCards()
    {
        while(true)
        {

            if(lastTwoCardFaceUp.Count == 2)
            {
                canFlip = false;
                Animator lastAnimator = lastTwoCardFaceUp[1].GetComponent<Animator>();

                yield return new WaitUntil(() => (lastAnimator.GetCurrentAnimatorStateInfo(0).IsName("CardFlip") && lastAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime>=1));

                if(lastTwoCardFaceUp[0].name == lastTwoCardFaceUp[1].name)
                {
                    print("Acertou");
                    allCardFaceUp.Add(lastTwoCardFaceUp[0]);
                    allCardFaceUp.Add(lastTwoCardFaceUp[1]);


                    if(allCardFaceUp.Count >= numberOfCards)
                    {
                        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

                        if(currentLevel == GameDataManager.instance.maxLevel)
                        {
                            PlayerPrefs.SetInt("CurrentLevel", currentLevel+1);
                            GameDataManager.instance.maxLevel++;
                        }

                        GameDataManager.instance.SaveData();
                        yield return new WaitForSeconds(0.5f);
                        SceneManager.LoadScene(1);
                    }
                }
                else
                {
                    print("Errou");
                    yield return new WaitForSeconds(0.5f);
                    lastTwoCardFaceUp[0].GetComponent<Card>().FlipOut();
                    yield return new WaitForSeconds(0.3f);
                    lastTwoCardFaceUp[1].GetComponent<Card>().FlipOut();

                }

                lastTwoCardFaceUp = new List<GameObject>();
                canFlip = true;
            }

            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }


    void CreateCards()
    {
        sprites = new List<Sprite>(Resources.LoadAll<Sprite>(sheetname));
        names = new string[sprites.Count];

        if(numberOfCards > sprites.Count*2)
            numberOfCards = sprites.Count*2;

        for(int c=0; c<numberOfCards; c+=2)
        {
            Sprite spt = sprites[Random.Range(0, sprites.Count)];
            Color cor = new Color(Random.value,Random.value,Random.value);

            GameObject cardTmp = Instantiate(cardModel, cardGrid.transform) as GameObject;
            cardTmp.transform.GetChild(1).GetComponent<SpriteRenderer>().color = cor;
            cardTmp.GetComponent<Card>().frontIcon.sprite = spt;
            // cardTmp.GetComponent<Card>().frontIconShadow.sprite = spt;
            cardTmp.GetComponent<Card>().CM = this;

            cardTmp = Instantiate(cardModel, cardGrid.transform) as GameObject;
            cardTmp.transform.GetChild(1).GetComponent<SpriteRenderer>().color = cor;
            // cardTmp.GetComponent<SpriteRenderer>().color = cor;
            cardTmp.GetComponent<Card>().frontIcon.sprite = spt;
            // cardTmp.GetComponent<Card>().frontIconShadow.sprite = spt;
            cardTmp.GetComponent<Card>().CM = this;

            sprites.Remove(spt);
        }

        SortCards();
    }

    public void PickCard(GameObject card)
    {
        lastTwoCardFaceUp.Add(card);
    }


    void SortCards()
    {
        int[] newIndexs = new int[numberOfCards];

        for(int c=0; c<numberOfCards; c++)
        {
            newIndexs[c] = Random.Range(0, numberOfCards);
        }

        int cc=0;
        foreach(int idx in newIndexs)
        {
            Transform child = cardGrid.transform.GetChild(cc);
            child.SetSiblingIndex(idx);
            cc++;
        }
    }


}
