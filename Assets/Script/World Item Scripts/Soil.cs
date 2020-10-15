using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Soil : MonoBehaviour
{

    private Animator anim;
    private GameObject droplets;
    private Plant plant;

    private bool IsPlanted = false;
    private float seconds = 0;
    private float saveSeconds = 0;
    private float interval;
    private int stages;

    private int i = 0;
    private bool isDroplets = false;
    private string[] plant_trigger;
    public bool harvestTime = false;
    string uniqueName;

    public GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        droplets = transform.parent.Find("droplets").gameObject;
        uniqueName = gameObject.name + UIStatics.numb;
        UIStatics.numb++;
        LoadSave();
    }

    void Update()
    {

        if (IsPlanted)
        {
            seconds += Time.deltaTime % 60;

            if (seconds >= interval && interval != plant.secondsLength + 1)
            {
                droplets.SetActive(true);
                anim.SetTrigger("end");
                anim.SetTrigger(plant_trigger[i + 1]);
                interval = interval + plant.secondsLength / stages;
                plant.level = i;
                i++;
                isDroplets = true;
                saveSeconds += seconds;
                if(i+1 == plant_trigger.Length)
                {
                    IsPlanted = false;
                    seconds = 0;
                    i = 0;
                    harvestTime = true;
                    droplets.SetActive(false);
                }
                Save();
            }

            if(isDroplets)
                seconds = 0f;

            plant.consumeSeconds = seconds + saveSeconds;
        }

    }

    public void Dilig()
    {
        isDroplets = false;
        droplets.SetActive(false);
    }

    public bool isDilig()
    {
        return isDroplets;
    }

    public void HarvestTime(Item.ItemType type)
    {
        PlayerNecessity.Instance.GetInventory().AddItem(new Item { itemType = SetTypeNonSeed(type), amount = 1 });
        anim.SetTrigger("end");
        harvestTime = false;
        IsPlanted = false;
        if (SaveLoad.SaveExist(uniqueName))
            SaveLoad.DeleteFilesSaved(uniqueName);
    }

    public void PlantSeed(string name)
    {
        IsPlanted = true;
        switch (name)
        {
            case "Talong":
                plant = new Plant(Plant.PlantType.Talong);
                interval = plant.secondsLength / Plant.eggplant_triggers.Length;
                anim.SetTrigger(Plant.eggplant_triggers[0]);
                stages = Plant.eggplant_triggers.Length;
                plant_trigger = Plant.eggplant_triggers;
                Debug.Log("Stages " + stages);
                break;
            case "Palay":
                plant = new Plant(Plant.PlantType.Palay);
                interval = plant.secondsLength / Plant.palay_triggers.Length;
                anim.SetTrigger(Plant.palay_triggers[0]);
                stages = Plant.palay_triggers.Length;
                plant_trigger = Plant.palay_triggers;
                break;
            case "Sibuyas":
                plant = new Plant(Plant.PlantType.Sibuyas);
                interval = plant.secondsLength / Plant.sibuyas_triggers.Length;
                anim.SetTrigger(Plant.sibuyas_triggers[0]);
                stages = Plant.sibuyas_triggers.Length;
                plant_trigger = Plant.sibuyas_triggers;
                break;
            case "Repolyo":
                plant = new Plant(Plant.PlantType.Repolyo);
                interval = plant.secondsLength / Plant.repolyo_triggers.Length;
                anim.SetTrigger(Plant.repolyo_triggers[0]);
                stages = Plant.repolyo_triggers.Length;
                plant_trigger = Plant.repolyo_triggers;
                break;
            case "Carrots":
                plant = new Plant(Plant.PlantType.Carrots);
                interval = plant.secondsLength / Plant.carrots_triggers.Length;
                anim.SetTrigger(Plant.carrots_triggers[0]);
                stages = Plant.carrots_triggers.Length;
                plant_trigger = Plant.carrots_triggers;
                break;
            case "Kamatis":
                plant = new Plant(Plant.PlantType.Kamatis);
                interval = plant.secondsLength / Plant.kamatis_triggers.Length;
                anim.SetTrigger(Plant.kamatis_triggers[0]);
                stages = Plant.kamatis_triggers.Length;
                plant_trigger = Plant.kamatis_triggers;
                break;
        }
    }


    public Item.ItemType SetTypeNonSeed(Item.ItemType type)
    {
        switch (type)
        {
            default: return Item.ItemType.None;
            case Item.ItemType.Talong: return Item.ItemType.NonSeed_Talong;
            case Item.ItemType.Sibuyas: return Item.ItemType.NonSeed_Sibuyas;
            case Item.ItemType.Kamatis: return Item.ItemType.NonSeed_Kamatis;
            case Item.ItemType.Palay: return Item.ItemType.NonSeed_Palay;
            case Item.ItemType.Carrots: return Item.ItemType.NonSeed_Carrots;
            case Item.ItemType.Repolyo: return Item.ItemType.NonSeed_Repolyo;
        }
    }

    void Save()
    {
         SerializeSoil soil = new SerializeSoil(
         IsPlanted,
         seconds,
         saveSeconds,
         interval,
         stages,
         i,
         isDroplets,
         plant_trigger,
         harvestTime,
         plant
         );

        SaveLoad.Save<SerializeSoil>(soil, uniqueName);
    }

    void LoadSave()
    {
        if (SaveLoad.SaveExist(uniqueName))
        {
            SerializeSoil soil = SaveLoad.Load<SerializeSoil>(uniqueName);

            this.IsPlanted = soil.IsPlanted;
            this.seconds = soil.seconds;
            this.saveSeconds = soil.saveSeconds;
            this.interval = soil.interval;
            this.stages = soil.stages;
            this.i = soil.i;
            this.isDroplets = soil.isDroplets;
            this.plant_trigger = soil.plant_trigger;
            this.harvestTime = soil.harvestTime;
            this.plant = soil.plant;
            anim.SetTrigger(plant_trigger[i]); 
            droplets.SetActive(isDroplets);


        }
    }

}
