using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjects
{

    public enum ObjectType
    {
        Bucket,
        Pala,
        BahayKubo,
        Crops,
    }

    public static GameObject currentCrop;
    public static GameObject latestCrop;
    public static GameObject popUpBox;
    public static Animator popUpAnim;
    public static ObjectType objectType;

}
