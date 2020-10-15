using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMarket : MonoBehaviour
{
    public static UIMarket Instance{ get; private set;}

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

}
