using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void Load(int sceneNum = 1)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
