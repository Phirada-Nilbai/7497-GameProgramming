using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private int playerLives = 3;

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
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
        playerLives--;

        switch (playerLives)
        {
            case >= 1:
                LoadScene(GetCurrentBuildIndex());
                UpdateLives();
                break;
            default:
                ReturnToMainMenu();
                break;
        }
    }

    public void ReturnToMainMenu()
    {
        LoadScene(0);
        Destroy(gameObject);
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1;
        }

        //yield return new WaitForSeconds(0.15f);
        LoadScene(nextSceneIndex);   
        }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        DOTween.KillAll();
    }

    private void UpdateLives()
    {
        uiManager.UpdateLives(playerLives);
    }
}
