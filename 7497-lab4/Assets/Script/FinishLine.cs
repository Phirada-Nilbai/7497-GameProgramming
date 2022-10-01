using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    private GameManager _gameManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if(_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        _gameManager.TriggerNextScene();
    }

}
