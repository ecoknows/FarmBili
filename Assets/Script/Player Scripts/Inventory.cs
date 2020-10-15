using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;
    private List<Item> sellList;
    public event EventHandler OnItemListChanged;
    public event EventHandler OnSellListChanged;


     void Start()
    {
        itemList = new List<Item>();
        sellList = new List<Item>();

    }

    public void AddItem(Item item)
    {
        if (item.isStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if(inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }

        Save();
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SellItema(Item item)
    {
        if (item.isStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in sellList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                sellList.Add(item);
            }
        }
        else
        {
            sellList.Add(item);
        }

        Save();
        OnSellListChanged?.Invoke(this, EventArgs.Empty);
    }


    public Item GetItem(string item)
    {
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType.ToString() == item)
                {
                      return inventoryItem;
                }
            }
        return null;
    }

    public void ConcumeItem(Item item)
    {
        if (item.isStackable()) { 
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount--;
                }
            }

        }

        Save();
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public void ConcumeItemAmmount(Item item)
    {
        if (item.isStackable())
        {
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount = item.amount;
                }
            }

        }

        Save();
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public void RemoveToInventory(Item item)
    {
        itemList.Remove(item);
        Save();
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveToSellInventory(Item item)
    {
        sellList.Remove(item);
        Save();
        OnSellListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }


    public List<Item> SellItemList()
    {
        return sellList;
    }

    public void SellItem(Item.ItemType item)
    {

        foreach (Item inventoryItem in itemList)
        {
            if(item == inventoryItem.itemType)
            {
                if (inventoryItem.amount != 0)
                {
                    SellItema(new Item { itemType = inventoryItem.itemType, amount = 1 });
                }
                inventoryItem.amount--;

            }
        }

        Save();
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

    }

    public void AddItems(List<Item> items)
    {
        foreach(Item item in items)
        {
            AddItem(item);
        }
    }


    public void SellItems(List<Item> items)
    {
        Debug.Log(" heyo " + items.Count);
        foreach (Item item in items)
        {
            SellItema(item);
        }
    }


    public void buyItem(int addition)
    {

        if (sellList.Count > 0)
        {
           
            int x = UnityEngine.Random.Range(0, sellList.Count);
            sellList[x].amount--;
            PlayerNecessity.Instance.AddMoney(Item.getPrice(sellList[x].itemType) + addition);
            OnSellListChanged?.Invoke(this, EventArgs.Empty);
            Save();
        }
    }

    void Save()
    {
        ItemLists items = new ItemLists(itemList, sellList);
        SaveLoad.Save<ItemLists>(items, "Inventory");
    }


    public void Load()
    {
        if (SaveLoad.SaveExist("Inventory"))
        {
            ItemLists items = SaveLoad.Load<ItemLists>("Inventory");
            AddItems(items.itemList);
            Debug.Log(items.sellList + " ye" );
            SellItems(items.sellList);
        }
    }



}
