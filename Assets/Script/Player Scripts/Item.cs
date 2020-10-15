using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item {

    public enum ItemType
    {
        Coin,
        Talong,
        Sibuyas,
        Palay,
        Kamatis,
        Carrots,
        Repolyo,


        NonSeed_Talong,
        NonSeed_Sibuyas,
        NonSeed_Palay,
        NonSeed_Kamatis,
        NonSeed_Carrots,
        NonSeed_Repolyo,


        None,
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Talong: return ItemAssets.Instance.Talong;
            case ItemType.Sibuyas: return ItemAssets.Instance.Sibuyas;
            case ItemType.Kamatis: return ItemAssets.Instance.Kamatis;
            case ItemType.Palay: return ItemAssets.Instance.Palay;
            case ItemType.Carrots: return ItemAssets.Instance.Carrots;
            case ItemType.Repolyo: return ItemAssets.Instance.Repolyo;


            case ItemType.NonSeed_Talong: return ItemAssets.Instance.NonSeed_Talong;
            case ItemType.NonSeed_Sibuyas: return ItemAssets.Instance.NonSeed_Sibuyas;
            case ItemType.NonSeed_Kamatis: return ItemAssets.Instance.NonSeed_Kamatis;
            case ItemType.NonSeed_Palay: return ItemAssets.Instance.NonSeed_Palay;
            case ItemType.NonSeed_Carrots: return ItemAssets.Instance.NonSeed_Carrots;
            case ItemType.NonSeed_Repolyo: return ItemAssets.Instance.NonSeed_Repolyo;

        }
    }

    public bool isStackable()
    {
        switch(itemType){
            default:
            case ItemType.Talong:
            case ItemType.Sibuyas:
            case ItemType.Kamatis:
            case ItemType.Palay:
            case ItemType.Carrots:
            case ItemType.Repolyo:

            case ItemType.NonSeed_Talong:
            case ItemType.NonSeed_Sibuyas:
            case ItemType.NonSeed_Kamatis:
            case ItemType.NonSeed_Palay:
            case ItemType.NonSeed_Carrots:
            case ItemType.NonSeed_Repolyo:
                return true;

        }
    }

    public static int getPrice(ItemType item)
    {
        switch (item)
        {
            default:
                return 0;
            case ItemType.Talong:
                return 10;
            case ItemType.Kamatis:
                return 20;
            case ItemType.Palay:
                return 30;
            case ItemType.Sibuyas:
                return 40;
            case ItemType.Carrots:
                return 50;
            case ItemType.Repolyo:
                return 60;
            case ItemType.NonSeed_Talong:
                return 30;
            case ItemType.NonSeed_Sibuyas:
                return 40;
            case ItemType.NonSeed_Kamatis:
                return 50;
            case ItemType.NonSeed_Palay:
                return 60;
            case ItemType.NonSeed_Carrots:
                return 70;
            case ItemType.NonSeed_Repolyo:
                return 80;

        }
    }

}
