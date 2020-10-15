using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryItem : MonoBehaviour
{
    public Item.ItemType item;
    public void onSell(GameObject obj)
    {
        int amount = Convert.ToInt32(obj.transform.Find("amount").gameObject.GetComponent<TextMeshProUGUI>().text);
        amount--;
        obj.transform.Find("amount").gameObject.GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        PlayerNecessity.Instance.GetInventory().SellItem(item);

    }
}
