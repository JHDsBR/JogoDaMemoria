using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : MonoBehaviour
{
    public SpriteRenderer frontIcon;
    public Animator cardAnimator;

    // Start is called before the first frame update
    void Start()
    {
        if(!cardAnimator)
        {
            cardAnimator = GetComponent<Animator>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        // Debug.Log("You clicked me");
        cardAnimator.SetBool("FlipIn", true);
    }

}
