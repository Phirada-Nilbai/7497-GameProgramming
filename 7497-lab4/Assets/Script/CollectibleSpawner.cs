using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject collectibleGameObject;
    [SerializeField] private Transform endMovePoint;
    [Header("Collectible Settings")]
    [SerializeField] private float respawnTime = 4f;

    private void Start()
    {
        DOTween();
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

    public void DOTween()
    {
        transform.DOMove(endMovePoint.position, 3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuart);
    }
    public void StartRespawningCountdown() 
    {
        SetOutlineSpriteActive(true);
        StartCoroutine(RespawnCollectible());
    }
}