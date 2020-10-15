using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class unlock : MonoBehaviour
{
    public GameObject obj;
    private bool isUnlock;
     void Start()
    {
        isUnlock = false;
        Load();

        obj.SetActive(!isUnlock);
    }

    private void OnMouseDown()
    {
            if(UIStatics.oneTimeObject != null)
                UIStatics.oneTimeObject.SetActive(false);
            GameObject requirements = gameObject.transform.Find("Requirements").gameObject;
            requirements.SetActive(true);
            UIStatics.oneTimeObject = requirements;

            int coin = Convert.ToInt32(gameObject.transform.Find("Requirements").gameObject.transform.Find("Coin").gameObject.transform.Find("amount").GetComponent<TextMeshPro>());
            int water = Convert.ToInt32(gameObject.transform.Find("Requirements").gameObject.transform.Find("Water").gameObject.transform.Find("amount").GetComponent<TextMeshPro>());
            int itemAmount = Convert.ToInt32(gameObject.transform.Find("Requirements").gameObject.transform.GetChild(0).gameObject.transform.Find("amount").GetComponent<TextMeshPro>());
            Item item = PlayerNecessity.Instance.GetInventory().GetItem(gameObject.transform.Find("Requirements").gameObject.transform.GetChild(0).gameObject.name);
            if (item != null)
                if (item.amount >=itemAmount && PlayerNecessity.Instance.Money >= coin && PlayerNecessity.Instance.Water >= water )
                {
                    item.amount -= itemAmount;
                    PlayerNecessity.Instance.ConsumeMoney(Convert.ToInt32(coin));
                    PlayerNecessity.Instance.ConsumeWater(5);
                    PlayerNecessity.Instance.GetInventory().ConcumeItemAmmount(item);

                    obj.SetActive(false);
                    isUnlock = true;
                    Save();
                }
    }


    void Save()
    {
        SaveLoad.Save<bool>(isUnlock, obj.name);
    }

    void Load()
    {
        if(SaveLoad.SaveExist(obj.name))
            isUnlock = SaveLoad.Load<bool>(obj.name);
    }

}
