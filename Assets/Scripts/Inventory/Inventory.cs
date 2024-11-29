using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> items;

    //constructor
    public Inventory()
    {
        items = new List<Item>();

        //Just for demo
        AddItem(new Item { itemType = Item.ItemType.Photo, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Letter, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Letter, amount = 1 });

        //Printing Count of items
        Debug.Log(items.Count);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList() { 
        return items;
    }
}
