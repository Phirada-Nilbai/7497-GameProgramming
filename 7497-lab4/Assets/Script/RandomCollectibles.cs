using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomCollectibles : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = new Sprite[3];
    [SerializeField] private int numbers ;

    public enum CollectibleType
    {
        Red,
        Blue ,
        Green,
        
    }

    public CollectibleType collectibleType;
    private void Start()
    {
        numbers = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[numbers];

        if (numbers == 0)
        {
            collectibleType = CollectibleType.Red;
        }
        else if (numbers == 1)
        {
            collectibleType = CollectibleType.Blue;
        }
        else if (numbers == 2)
        {
            collectibleType= CollectibleType.Green;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        base.gameObject.SetActive(false);

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
        }
    }
}

