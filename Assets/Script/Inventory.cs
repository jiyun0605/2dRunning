using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject[] slots;
    bool canUse;
    public bool AddItem(Item item)
    {
        if (items.Count >= 4)
            return false;
        items.Add(item);
        slots[items.Count - 1].GetComponent<Image>().sprite = item.itemSprite;

        return true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FieldItem")
        {
            FieldItem fieldItem = collision.gameObject.GetComponent<FieldItem>();
            if (AddItem(fieldItem.GetItem()))
            {
                fieldItem.DestroyItem();
            }
        }
        if (collision.gameObject.tag == "NPC")
        {
            canUse = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="NPC")
        {
            canUse = false;
        }
    }
    public void Use(int n)
    {
        if (!canUse)
            return;
        items[n].Use();
    }
}
