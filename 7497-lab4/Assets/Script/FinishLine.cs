using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private const string PlayerTag = "Player";

    private GameManager _gameManager;

    private bool _triggeredNextScene;


  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(PlayerTag)) return;

        if (_triggeredNextScene) return;

        _triggeredNextScene = true;  
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.LoadNextLevel();
        audioSource.Play();
    }
}