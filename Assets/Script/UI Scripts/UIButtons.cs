using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    string TAG;
    public SpriteRenderer indicator;

    public void onClick()
    {
        TAG = gameObject.name;
        if(TAG == "Market")
        {
            PopUpSystem.Instance.PopUpMarket();
        }
        else
        {
            if (TAG == "Pala")
                indicator.sprite = ItemAssets.Instance.Pala;
            if (TAG == "Timba")
                indicator.sprite = ItemAssets.Instance.WaterCan;
            UIStatics.CURRENT_PICK = TAG;
        }   

    }




}
