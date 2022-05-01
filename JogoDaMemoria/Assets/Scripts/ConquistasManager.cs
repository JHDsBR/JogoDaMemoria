using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConquistasManager : MonoBehaviour
{
    public Text cardsTurnedValueShadow;

    // Start is called before the first frame update
    void Start()
    {
        cardsTurnedValueShadow.text = GameDataManager.instance.numberOfCardsTurned.ToString();
        cardsTurnedValueShadow.transform.GetChild(0).GetComponent<Text>().text = GameDataManager.instance.numberOfCardsTurned.ToString();
    }

}
