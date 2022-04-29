using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public bool loadOnAwake;
    public int sceneToLoad;

    void Start()
    {
        if(loadOnAwake)
        {
            StartCoroutine(WaitLoad(sceneToLoad));
        }
    }

    public void Load(int sceneNum = 2)
    {
        SceneManager.LoadScene(sceneNum);
    }

    IEnumerator WaitLoad(int l)
    {
        yield return new WaitForSeconds(1);
        Load(l);
    }

    public void LoadLastLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", GameDataManager.instance.maxLevel);
        Load();
    }
}
