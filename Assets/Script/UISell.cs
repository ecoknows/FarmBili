using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISell : MonoBehaviour
{

    public static UISell Instance { get; private set; }

    public Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        inventory = PlayerNecessity.Instance.inventory; 
        SetInventory(inventory);
        itemSlotContainer = transform.Find("Scroll").Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnSellListChanged += Inventory_OnSellListChanged;
    }

    private void Inventory_OnSellListChanged(object sender, System.EventArgs e)
    {
        RefreshInventory();
    }


    private void RefreshInventory()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;
        Item itemToBeRemoved = null;
        foreach (Item item in inventory.SellItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI amount = itemSlotRectTransform.Find("amount").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI price = itemSlotRectTransform.Find("price").GetComponent<TextMeshProUGUI>();

            price.SetText(Item.getPrice(item.itemType).ToString());




            if (item.amount > 0)
            {
                amount.SetText(item.amount.ToString());
            }
            else
            {
                itemToBeRemoved = item;
            }

            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }


        if (itemToBeRemoved != null)
        {
            inventory.RemoveToSellInventory(itemToBeRemoved);
        }

    }




}
