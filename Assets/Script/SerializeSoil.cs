using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerializeSoil
{

    public bool IsPlanted = false;
    public float seconds = 0;
    public float saveSeconds = 0;
    public float interval;
    public int stages;

    public int i = 0;
    public bool isDroplets = false;
    public string[] plant_trigger;
    public bool harvestTime = false;
    public Plant plant;

    public SerializeSoil(
        bool IsPlanted,
        float seconds,
        float saveSeconds,
        float interval,
        int stages,
        int i,
        bool isDroplets,
        string[] plant_trigger,
        bool harvestTime,
        Plant plant
       )
    {
        this.IsPlanted = IsPlanted;
        this.seconds = seconds;
        this.saveSeconds = saveSeconds;
        this.interval = interval;
        this.stages = stages;
        this.i = i;
        this.isDroplets = isDroplets;
        this.plant_trigger = plant_trigger;
        this.harvestTime = harvestTime;
        this.plant = plant;
    }
}
