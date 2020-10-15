using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerNecessity : MonoBehaviour
{

    public static PlayerNecessity Instance { get; private set; }

    public int Money;
    public int Water;
    public Inventory inventory;
    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI waterText;

    void Awake()
    {
        if (Instance == null)
        {
            LoadSave();
            inventory = gameObject.transform.parent.gameObject.transform.Find("Inventory").gameObject.GetComponent<Inventory>();
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void UpdatePlayer()
    {
        waterText = UIIStatus.Instance.gameObject.transform.Find("Bucket").gameObject.transform.Find("amount").GetComponent<TextMeshProUGUI>();
        moneyText = UIIStatus.Instance.gameObject.transform.Find("Coin").gameObject.transform.Find("amount").GetComponent<TextMeshProUGUI>();
        waterText.SetText(Water.ToString());
        moneyText.SetText(Money.ToString());
    }


    public Inventory GetInventory()
    {
        return inventory;
    }


    public void RefillWater()
    {
        waterText = UIIStatus.Instance.gameObject.transform.Find("Bucket").gameObject.transform.Find("amount").GetComponent<TextMeshProUGUI>();

        Water = 10;

        waterText.SetText(Water.ToString());
        Save();
    }

    public void ConsumeWater()
    {
        waterText = UIIStatus.Instance.gameObject.transform.Find("Bucket").gameObject.transform.Find("amount").GetComponent<TextMeshProUGUI>();

        Water -= 1;
        waterText.SetText(Water.ToString());
        Save();
    }
    public void ConsumeWater(int x)
    {
        waterText = UIIStatus.Instance.gameObject.transform.Find("Bucket").gameObject.transform.Find("amount").GetComponent<TextMeshProUGUI>();

        Water -= x;
        waterText.SetText(Water.ToString());
        Save();
    }


    public void AddMoney(int price)
    {
        moneyText = UIIStatus.Instance.gameObject.transform.Find("Coin").gameObject.transform.Find("amount").GetComponent<TextMeshProUGUI>();

        Money += price;
        moneyText.SetText(Money.ToString());
        Save();
    }

    public void ConsumeMoney(int price)
    {
        moneyText = UIIStatus.Instance.gameObject.transform.Find("Coin").gameObject.transform.Find("amount").GetComponent<TextMeshProUGUI>();

        Money -= price;
        moneyText.SetText(Money.ToString());
        Save();
    }

    void Save()
    {
        Wealth wealth = new Wealth(Money, Water);
        SaveLoad.Save<Wealth>(wealth, "Wealth");
    }

    void LoadSave()
    {

        if (SaveLoad.SaveExist("Wealth"))
        {
           Wealth wealth = SaveLoad.Load<Wealth>("Wealth");
            Money = wealth.money;
            Water = wealth.water;

        }
        else
        {
            Money = 250;
            Water = 10;

            Save();

        }

    }



}
