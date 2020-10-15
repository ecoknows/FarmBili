using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
   public static ItemAssets Instance { get; private set; }

   void Start()
    {
        Instance = this;
    }

    public Sprite Talong;
    public Sprite Sibuyas;
    public Sprite Kamatis;
    public Sprite Palay;
    public Sprite Repolyo;
    public Sprite Carrots;


    public Sprite NonSeed_Talong;
    public Sprite NonSeed_Sibuyas;
    public Sprite NonSeed_Kamatis;
    public Sprite NonSeed_Palay;
    public Sprite NonSeed_Repolyo;
    public Sprite NonSeed_Carrots;


    public Sprite WaterCan;
    public Sprite Pala;

    public Sprite couple;
    public Sprite theif;
    public Sprite pakyaw;

}
