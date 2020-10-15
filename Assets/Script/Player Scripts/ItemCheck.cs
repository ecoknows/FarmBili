using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    public GameObject popUpSystem;


    private void OnTriggerEnter2D(Collider2D coillder)
    {
        switch(gameObject.tag)
        {
            case "BahayKubo":
                PopUpSystem pop = popUpSystem.GetComponent<PopUpSystem>(); // PWEDE SYANG MAG TANIM
                pop.PopUpInventory();
                break;
            case "Well":
                PlayerNecessity.Instance.RefillWater();
                Debug.Log("Heyo");
                break;
        }
    }
}
