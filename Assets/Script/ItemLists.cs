using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemLists
{
    public List<Item> itemList;
    public List<Item> sellList;

    public ItemLists(List<Item> itemList, List<Item> sellList)
    {
        this.itemList = itemList;
        this.sellList = sellList;
    }

}
