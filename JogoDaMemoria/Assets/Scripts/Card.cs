using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{
    public Image frontIcon;
    public Animator cardAnimator;
    public CardManager CM; // o própio CardManager que define essa variável

    private bool imFacedUp;

    // Start is called before the first frame update
    void Start()
    {
        if(!cardAnimator)
            cardAnimator = GetComponent<Animator>();

        gameObject.name = "Card "+frontIcon.sprite.name; // muda o nome do gameObject, é através desse nome que é feito a comparação dos cards

    }


    void OnMouseDown()
    {
        // Debug.Log("You clicked me");

        if(imFacedUp || !CM.canFlip)
            return;

        FlipIn();
        GameDataManager.instance.numberOfCardsTurned++;
        CM.PickCard(gameObject);
    }


    public void FlipIn()
    {
        GamePlayManager.instance.flidSound.Play();

        imFacedUp = true;
        cardAnimator.SetBool("FlipIn", true);
        cardAnimator.SetBool("FlipOut", false);
    }


    public void FlipOut()
    {
        imFacedUp = false;
        cardAnimator.SetBool("FlipOut", true);
        cardAnimator.SetBool("FlipIn", false);
    }

}
