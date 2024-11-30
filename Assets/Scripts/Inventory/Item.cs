using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Photo,
        Letter,
    }

    public ItemType itemType;

    [SerializeField] private Sprite popupSprite;

    public Sprite GetSprite()
    {
        switch(itemType)
        {

            case ItemType.Photo: return ItemAssets.Instance.photographSprite;
            case ItemType.Letter: return ItemAssets.Instance.LetterSprite;
            default: return null;
        }
    }

    public Sprite GetPopupSprite()
    {
        return popupSprite;
    }

    public void SetPopupSprite(Sprite sprite)
    {
        popupSprite = sprite;
    }
}
