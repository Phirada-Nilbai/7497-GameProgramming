using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private CollectibleSpawner collectibleSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SoCollectibles collectibleObject;
    [SerializeField] private Transform endMovePoint;
    private GameManager gameManager;

    private CollectibleType _collectibleType;
    private bool _isRespawnable;

    private void Start()
    {
        DOTween();
        SetCollectible();
    }

    public CollectibleType GetCollectibleInfoOnContact()
    {
        gameObject.SetActive(false);

        if (_isRespawnable)
        {
            collectibleSpawner.StartRespawningCountdown();
        }

        return _collectibleType;
    }

    private void SetCollectible()
    {
        collectibleSpawner.SetOutlineSprite(collectibleObject.GetOutlineSprite());
        spriteRenderer.sprite = collectibleObject.GetSprite();
        _collectibleType = collectibleObject.GetCollectibleType();
        _isRespawnable = collectibleObject.GetRespawnable();
    }
    public void DOTween()
    {
        transform.DOMove(endMovePoint.position, 3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuart);
    }
}