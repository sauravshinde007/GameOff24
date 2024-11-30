using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;
    public Sprite popupSprite; //Clue Image for player to see

    private void Start()
    {
        item.SetPopupSprite(popupSprite);

        ItemWorld.SpawnItemWorld(transform.position, item);

        //Destroy the spawner
        Destroy(gameObject);
    }
}

