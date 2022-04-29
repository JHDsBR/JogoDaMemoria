using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public GameObject lifeModel;

    int vidas;

    // Start is called before the first frame update
    void Start()
    {
        vidas = GameDataManager.instance.maxLifes;
        CreateLifes();
        StartCoroutine("UpdateLifeCount");
    }


    void CreateLifes()
    {
        for(int c=0; c<vidas; c++)
        {
            Instantiate(lifeModel, transform);
        }
    }


    IEnumerator UpdateLifeCount()
    {
        while(vidas > 0)
        {
            if(GameDataManager.instance.currentLifes < vidas)
            {
                vidas = GameDataManager.instance.currentLifes;
                Destroy(transform.GetChild(0).gameObject, .0f);
            }

            yield return null;
        }

        print("GameOver");

        // SceneManager.LoadScene(1);

    }



    // public void LoadLastLevel()
    // {
    //     PlayerPrefs.SetInt("CurrentLevel", GameDataManager.instance.maxLevel);
    //     Load();
    // }
}
