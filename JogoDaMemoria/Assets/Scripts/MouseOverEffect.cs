using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverEffect : MonoBehaviour
{

    public float smoothAmount = 0.25f;

    Vector2 mouseStartPos;
    Vector2 myStartPos;
    Vector2 center=Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        center.x = Screen.width / 2;
        center.y = Screen.height / 2;

        center = Camera.main.ScreenToWorldPoint(center);

        myStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseMovementDirection = currentMousePosition-center;
        // print(currentMousePosition);

        transform.position = myStartPos-mouseMovementDirection*smoothAmount;
    }
}
