using System.Collections;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
   
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject collectibleGameObject;

    [Header("Collectible Settings")]
    [SerializeField] private float respawnTime = 4f;

    private void Start()
    {
        spriteRenderer.enabled = false;
    }

    private IEnumerator RespawnCollectible()
    {
        yield return new WaitForSeconds(respawnTime);
        SetOutlineSpriteActive(false);
        collectibleGameObject.SetActive(true);
    }

    private void SetOutlineSpriteActive(bool state)
    {
        spriteRenderer.enabled = state;
    }

    public void SetOutlineSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public void StartRespawningCountdown() 
    {
        SetOutlineSpriteActive(true);
        StartCoroutine(RespawnCollectible());
    }
}
