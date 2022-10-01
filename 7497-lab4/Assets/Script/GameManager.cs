using DG.Tweening;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LivesTextDisplay livesTextDisplay;
    [SerializeField] private int lives = 3;

    private bool _isGameOver = true;

  
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

    private void Start()
    {
        UpdateLives();
    }


    public void ProcessPlayerDeath()
    {
        lives -= 1;
        UpdateLives();
        RestartScene();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex());
    }
    
    public void LoadScene(int bulidIndex)
    {
        SceneManager.LoadScene(bulidIndex);
        DOTween.KillAll();
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
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UpdateLives()
    {
        livesTextDisplay.UpdateLives(lives);
    }
}
