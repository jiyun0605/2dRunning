using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemSprite;
    public int itemCode;
    public bool Use()
    {
        bool isUse = false;
        isUse = true;
        return isUse;
    }
}
