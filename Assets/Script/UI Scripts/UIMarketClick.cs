using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMarketClick : MonoBehaviour{

    public void OnClick(){

        if(PlayerNecessity.Instance.Money > 0)
            switch (gameObject.name)
            {
                case "Talong":
                    if(PlayerNecessity.Instance.Money - Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text) >= 0)
                    {
                        PlayerNecessity.Instance.ConsumeMoney(Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text));
                        PlayerNecessity.Instance.GetInventory().AddItem(new Item { itemType = Item.ItemType.Talong, amount = 1 });
                    }
                    break;
                case "Kamatis":
                    if (PlayerNecessity.Instance.Money - Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text) >= 0)
                    {
                        PlayerNecessity.Instance.ConsumeMoney(Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text));
                        PlayerNecessity.Instance.GetInventory().AddItem(new Item { itemType = Item.ItemType.Kamatis, amount = 1 });
                    }
                    break;
                case "Sibuyas":
                    if (PlayerNecessity.Instance.Money - Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text) >= 0)
                    {
                        PlayerNecessity.Instance.ConsumeMoney(Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text));
                        PlayerNecessity.Instance.GetInventory().AddItem(new Item { itemType = Item.ItemType.Sibuyas, amount = 1 });
                    }
                    break;
                case "Palay":
                    if (PlayerNecessity.Instance.Money - Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text) >= 0)
                    {
                        PlayerNecessity.Instance.ConsumeMoney(Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text));
                        PlayerNecessity.Instance.GetInventory().AddItem(new Item { itemType = Item.ItemType.Palay, amount = 1 });
                    }
                    break;
                case "Repolyo":
                    if (PlayerNecessity.Instance.Money - Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text) >= 0)
                    {
                        PlayerNecessity.Instance.ConsumeMoney(Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text));
                        PlayerNecessity.Instance.GetInventory().AddItem(new Item { itemType = Item.ItemType.Repolyo, amount = 1 });
                    }
                    break;
                case "Carrots":
                    if (PlayerNecessity.Instance.Money - Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text) >= 0)
                    {
                        PlayerNecessity.Instance.ConsumeMoney(Convert.ToInt32(transform.Find("price").GetComponent<TextMeshProUGUI>().text));
                        PlayerNecessity.Instance.GetInventory().AddItem(new Item { itemType = Item.ItemType.Carrots, amount = 1 });
                    }
                    break;
            }

    }
}
