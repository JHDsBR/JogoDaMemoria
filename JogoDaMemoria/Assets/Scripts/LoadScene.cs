using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public bool loadOnStart;
    public int sceneToLoadOnStart;

    public static LoadScene instance;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        if(loadOnStart)
        {
            StartCoroutine(LoadOnStart());
        }
    }

    IEnumerator LoadOnStart()
    {
        yield return new WaitUntil(() => GameDataManager.instance != null);
        Load(sceneToLoadOnStart);
    }

    public void Load(int sceneNum = 2)
    {
        GameDataManager.instance.maxLifes = 2 + (int)(Mathf.Floor(PlayerPrefs.GetInt("CurrentLevel", 1)/3)*1.5);;
        GameDataManager.instance.currentLifes = GameDataManager.instance.maxLifes;
        SceneManager.LoadScene(sceneNum);
    }


    public void LoadLastLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", GameDataManager.instance.maxLevel);
        Load();
    }


    public void LoadLevel(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);

        GameDataManager.instance.maxLifes = 2 + (int)(Mathf.Floor(PlayerPrefs.GetInt("CurrentLevel", 1)/3)*1.5);;
        GameDataManager.instance.currentLifes = GameDataManager.instance.maxLifes;

        SceneManager.LoadScene(2); // GamePlay

    }

    public void ReplayLastLevelPlayied()
    {
        LoadLevel(PlayerPrefs.GetInt("CurrentLevel", 1));
    }
}
