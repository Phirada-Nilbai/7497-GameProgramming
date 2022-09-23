using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Collider2D _playerCollider;

    private GameManager _gameManager;

    private void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {

            TakeDamage();
        }

            /*if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
            }

            _gameManager.ProcessPlayerDeath();
        }

   


        /*base.gameObject.SetActive(false);

        switch (collectibleType)
        {
            case CollectibleType.Red:
                collision.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case CollectibleType.Blue:
                collision.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case CollectibleType.Green:
                collision.GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }*/
    }

    private void TakeDamage()
    {
        Destroy(gameObject);

        if (_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        _gameManager.ProcessPlayerDeath();
    }
}
