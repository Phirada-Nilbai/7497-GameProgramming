using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        var numGameManagers = FindObjectsOfType<GameManager>().Length;

        if (numGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ProcessPlayerDeath()
    {
         RestartScene();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex());
    }

    public void TriggerNextScene()
    {
        StartCoroutine(LoadNextSecne());
    }

    private IEnumerator LoadNextSecne()
    {
        var nextSceneBulidIndex = GetCurrentSceneIndex() + 1;
        if (nextSceneBulidIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneBulidIndex = 0;
        }

        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(nextSceneBulidIndex);
    }
    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
