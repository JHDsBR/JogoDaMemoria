using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpGridOfSelectLevelButtons : MonoBehaviour
{
    public GameObject levelButtonModel;
    public int levelCount = 84;


    // Start is called before the first frame update
    void Start()
    {
        CreateGridOfButtons();
    }


    void CreateGridOfButtons()
    {
        for(int c=1; c<= levelCount; c++)
        {
            GameObject buttonTmp = Instantiate(levelButtonModel, transform) as GameObject;
            buttonTmp.GetComponent<SelectLevelButton>().myLevelInt = c;
            buttonTmp.GetComponent<SelectLevelButton>().text.text = c.ToString();
        }
    }
}
