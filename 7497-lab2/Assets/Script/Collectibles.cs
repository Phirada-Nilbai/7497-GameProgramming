using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //[SerializeField] private SoCollectible collectibleObject;
    //[SerializeField] SpriteRenderer spriteranderer;

    public enum CollectibleType
    {
        Red,
        Blue,
        Green,
    }


   
    public CollectibleType collectibleType;
    /*private void Start()
    {
        Debug.Log(collectibleObject.GetCollectibleType());
    }*/

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
    
