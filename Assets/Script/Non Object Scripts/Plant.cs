using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Plant
{

    public enum PlantType{
        Talong,
        Palay,
        Kamatis,
        Sibuyas,
        Repolyo,
        Carrots,
    }


    public static string[] eggplant_triggers = { "eggplant_1", "eggplant_2", "eggplant_3", "eggplant_4" , "eggplant_5", "eggplant_6", "eggplant_7" };
    public static string[] palay_triggers = { "palay_1", "palay_2", "palay_3", "palay_4", "palay_5", "palay_6", "palay_7" };
    public static string[] kamatis_triggers = { "kamatis_1", "kamatis_2", "kamatis_3", "kamatis_4", "kamatis_5", "kamatis_6", "kamatis_7" };
    public static string[] sibuyas_triggers = { "sibuyas_1", "sibuyas_2", "sibuyas_3", "sibuyas_4", "sibuyas_5", "sibuyas_6", "sibuyas_7" };
    public static string[] repolyo_triggers = { "repolyo_1", "repolyo_2", "repolyo_3", "repolyo_4", "repolyo_5", "repolyo_6", "repolyo_7" };
    public static string[] carrots_triggers = { "carrots_1", "carrots_2", "carrots_3", "carrots_4", "carrots_5", "carrots_6" };

    public PlantType type;
    public float secondsLength;
    public float consumeSeconds;
    public int level;

    public Plant(PlantType type)
    {
        this.type = type;
        switch (type)
        {
            case PlantType.Talong: this.secondsLength = 10; break;
            case PlantType.Palay: this.secondsLength = 120; break;
            case PlantType.Kamatis: this.secondsLength = 180; break;
            case PlantType.Sibuyas: this.secondsLength = 240; break;
            case PlantType.Repolyo: this.secondsLength = 300; break;
            case PlantType.Carrots: this.secondsLength = 360; break;
        }
    }


}
