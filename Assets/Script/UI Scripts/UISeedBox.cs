using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISeedBox : MonoBehaviour
{

    public static UISeedBox Instance { get; private set;}

    private Transform SeedContainer;
    private TextMeshProUGUI amount;

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

    private void Start()
    {
        SeedContainer = transform.Find("SeedContainer");
    }

    public void SetInventory(Inventory inventory)
    {
        foreach (Item item in inventory.GetItemList())
        {
            Transform trans = SeedContainer.Find(item.itemType.ToString());
            if(trans != null)
            {
                amount = trans.Find("amount").GetComponent<TextMeshProUGUI>();
                SeedContainer plant = SeedContainer.GetComponent<SeedContainer>();
                amount.SetText(item.amount.ToString());
            }
        }
    }

    public void PopUp(GameObject soil)
    {
        Debug.Log("Akoaypogi");
        Animator popUpBox = gameObject.GetComponent<Animator>();
        popUpBox.SetTrigger("Pop");

        gameObject.transform.Find("SeedContainer").gameObject.GetComponent<SeedContainer>().ObjectNeeded(soil, popUpBox);
    }



}
