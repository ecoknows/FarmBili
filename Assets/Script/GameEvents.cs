using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static System.Action<Item> ItemAddedToInventory;
    public static System.Action<string> ToolTipActivated;
    public static System.Action ToolTipDeactivated;
    public static System.Action SaveInitiated;
    public static System.Action LoadInitiated;


    public static void OnItemAddedToInventory(Item item)
    {
        ItemAddedToInventory?.Invoke(item);
    }

    public static void OnToolTipActivated(string text)
    {
        ToolTipActivated?.Invoke(text);
    }


    public static void OnToolTipDeactivated()
    {
        ToolTipDeactivated?.Invoke();
    }

    public static void OnSaveInitiated()
    {
        SaveInitiated?.Invoke();
    }

    public static void OnLoadInitiated()
    {
        SaveInitiated?.Invoke();
    }


}
