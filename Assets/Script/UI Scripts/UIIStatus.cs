using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIStatus : MonoBehaviour
{
   public static UIIStatus Instance { get; private set;}

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
