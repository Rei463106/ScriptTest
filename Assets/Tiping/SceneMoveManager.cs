using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    public void SceneMove(string  sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
