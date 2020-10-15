    using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollision : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public Item.ItemType itemType;
    public bool isHarvest;
    public bool isClicked;
    // public Button btn;


    private void Start()
    {
        isClicked = false;
        itemType = Item.ItemType.None;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" )
        {
            if(isClicked)
                Player();
        }



    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    private void Player()
    {

        switch (gameObject.tag)
        {
            case "BahayKubo":
                PopUpSystem.Instance.PopUpInventory();
                break;
            case "Well":
                PlayerNecessity.Instance.RefillWater();
                break;
            case "soil":
                Soil();
                break;
            case "sell":
                PopUpSystem.Instance.PopUpSell();
                break;
        }
    }

    void OnMouseDown()
    {

        switch (gameObject.tag)
        {
            case "sell":

                break;
            case "BahayKubo":
                if (UIStatics.oneTimeObject != null)
                {
                    UIStatics.oneTimeObject.gameObject.SetActive(false);
                }
                gameObject.transform.Find("icon").gameObject.SetActive(true);
                UIStatics.oneTimeObject = gameObject.transform.Find("icon").gameObject;
                break;
            case "Well":
                if (UIStatics.oneTimeObject != null)
                {
                    UIStatics.oneTimeObject.gameObject.SetActive(false);
                }
                gameObject.transform.Find("icon").gameObject.SetActive(true);
                UIStatics.oneTimeObject = gameObject.transform.Find("icon").gameObject;
                break;
            case "soil":
                if(UIStatics.oneTimeObject != null)
                {
                    UIStatics.oneTimeObject.gameObject.SetActive(false);
                }
                gameObject.transform.Find("planted").gameObject.SetActive(true);
                UIStatics.oneTimeObject = gameObject.transform.Find("planted").gameObject;

                break;
        }

        if (UIStatics.pastObject != null)
        {
            UIStatics.pastObject.isClicked = false;
        }

        isClicked = true;
        UIStatics.pastObject = this;
    }

    void Soil()
    {
        Soil soil = gameObject.transform.Find("plant").gameObject.GetComponent<Soil>();
        Debug.Log(itemType.ToString());

        if (soil.harvestTime)
        {
            soil.HarvestTime(itemType);
            itemType = Item.ItemType.None;
        }
        else
            switch (UIStatics.CURRENT_PICK)
            {
                case "Timba": if(isClicked) BucketCommand(); break;// didilig
                case "Pala": if(itemType == Item.ItemType.None && isClicked ) PopUpSystem.Instance.PopUpSeedBox(gameObject); break;
            }
    }

    void BucketCommand()
    {
        Soil soil = gameObject.transform.Find("plant").gameObject.GetComponent<Soil>();
        if (PlayerNecessity.Instance.Water != 0 && soil.isDilig())
        {
            Debug.Log("DILIG!");
            soil.Dilig();
            PlayerNecessity.Instance.ConsumeWater();
        }
        else
        {
            Debug.Log("NOT DILIG!");
            // DONT HAVE ENOUGH WATER
        }
        
    }

}
