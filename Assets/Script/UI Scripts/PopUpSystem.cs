using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{

    public static PopUpSystem Instance { get; private set;}

    public bool isIntro;

    public GameObject intro;


    void Start()
    {
        if(Instance == null)
        {
            isIntro = true;
            LoadIntro();
            if (isIntro)
                 PopUpIntro();
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }




    public void PopUpIntro()
    {
        intro.GetComponent<Animator>().SetTrigger("Pop");
    }

    public void PopUpSeedBox(GameObject soil)
    {
        UISeedBox.Instance.PopUp(soil);
    }

    
    public void PopUpMarket()
    {
        UIMarket.Instance.gameObject.SetActive(true);
        UIMarket.Instance.GetComponent<Animator>().SetTrigger("Pop");
    }


    public void PopUpInventory()
    {
        UIInventory.Instance.gameObject.SetActive(true);
        UIInventory.Instance.gameObject.GetComponent<Animator>().SetTrigger("Pop");
    }

    public void PopUpSell()
    {
        UISell.Instance.gameObject.SetActive(true);
        UISell.Instance.gameObject.GetComponent<Animator>().SetTrigger("Pop");
    }

     void LoadIntro()
    {
        if(SaveLoad.SaveExist("Intro"))
             isIntro = SaveLoad.Load<bool>("Intro");
    }

    public void SaveState()
    {
        isIntro = false;
        SaveLoad.Save<bool>(isIntro, "Intro");
    }

}
