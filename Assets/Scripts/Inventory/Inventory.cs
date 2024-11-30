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

        //Printing Count of items
        Debug.Log(items.Count);
    }

    public void AddItem(Item item)
    {
        if(item == null)
        {
            Debug.LogError("Item is null. Can't add it to the inventory.");
            return;
        }
        items.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public List<Item> GetItemList() { 
        return items;
    }
}
