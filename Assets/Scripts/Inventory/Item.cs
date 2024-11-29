using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Photo,
        Letter,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Photo: return ItemAssets.Instance.photographSprite;
            case ItemType.Letter: return ItemAssets.Instance.LetterSprite;
        }
    }
}
