using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public static Coin Instance { get; private set; }

    private TextMeshProUGUI amount;
    private int val = 0;

    void Start()
    {
        if(Instance == null)
        {
            PlayerNecessity.Instance.UpdatePlayer();
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetAmount(int val)
    {
        this.val = val;
        amount = gameObject.transform.Find("amount").gameObject.GetComponent<TextMeshProUGUI>();
        amount.SetText(val.ToString());
    }

    public void ConsumeAmmount()
    {
        val--;
        amount = gameObject.transform.Find("amount").gameObject.GetComponent<TextMeshProUGUI>();
        amount.SetText(val.ToString());
    }

    public int GetAmount()
    {
        return this.val;
    }



}
