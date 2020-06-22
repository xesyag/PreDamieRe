using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Coin,
        Sword
    }
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Coin: return ItemAssests.instance.coinSprite;
            case ItemType.Sword: return ItemAssests.instance.swordSprite;

        }
    }
}
