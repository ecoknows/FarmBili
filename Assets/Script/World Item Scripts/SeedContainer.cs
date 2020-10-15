using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedContainer : MonoBehaviour {

    private Animator popUpBox;
    private Soil soil;
    private ObjectCollision soilObject;

    public void Plant(GameObject seed)
    {
            Item currentItem = PlayerNecessity.Instance.GetInventory().GetItem(seed.gameObject.name);
            if (currentItem.amount != 0)
            {
                popUpBox.SetTrigger("Close");
                soil.PlantSeed(seed.name);
                soilObject.itemType = currentItem.itemType;

                PlayerNecessity.Instance.inventory.ConcumeItem(currentItem);
            }
    }


    public void ObjectNeeded(GameObject soil, Animator popUpBox)
    {
        this.popUpBox = popUpBox;
        this.soilObject = soil.GetComponent<ObjectCollision>();
        this.soil = soil.transform.Find("plant").GetComponent<Soil>();
    }


}
