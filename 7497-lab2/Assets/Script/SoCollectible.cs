using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Collectibles")]
public class SoCollectible : ScriptableObject
{
    public enum CollectibleType
    {
        DoubleJump,
        RefillHealth,
        RefilEnergy,
    }

    [SerializeField] private string collectibleName;
    [SerializeField] private CollectibleType collectbleType;

    public string GetCollectibleType()
    {
        return collectibleName;
    }
   /* [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private bool respawnable;

    public Sprite GetSprite() => sprite;
    public CollectibleType GetCollectibleType() => collectbleType;

    public Sprite GetOutlineSprite() => outlineSprite;
    
    public bool Respawnable => respawnable;*/
}
