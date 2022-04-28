using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardModel;
    public string sheetname;
    public GameObject cardGrid;
    private Sprite[] sprites;
    private SpriteRenderer sr;
    private string[] names;

    void Start ()
    {
        sprites = Resources.LoadAll<Sprite>(sheetname);
        // sr = GetComponent<SpriteRenderer>();
        names = new string[sprites.Length];

        foreach(Sprite spt in sprites)
        {
            // print(sprites[i].name);
            GameObject cardTmp = Instantiate(cardModel, cardGrid.transform) as GameObject;
            cardTmp.GetComponent<Card>().frontIcon.sprite = spt;
            // names[i] = sprites[i].name;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }


    void CreateCards()
    {

    }
}
