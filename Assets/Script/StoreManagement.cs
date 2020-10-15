using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class StoreManagement : MonoBehaviour
{
    public void OnPurcaseComplete(Product product)
    {
        switch (product.definition.id)
        {
            case "talong.free":
                Debug.Log("Free Talonf!");
                              break;
        }
    }
}

    
