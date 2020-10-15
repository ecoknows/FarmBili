using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Wealth 
{

    public int money;
    public int water;
    public Wealth(int money, int water)
    {
        this.money = money;
        this.water = water;
    }


}
