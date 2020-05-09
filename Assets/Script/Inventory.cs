using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject[] slots;
    public Sprite slotbase;
    bool canUse;
    NPC npc;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="NPC")
        {
            canUse = true;
            npc = collision.gameObject.GetComponent<NPC>();
            npc.ShowNeed();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            canUse = false;
            npc = null;
        }
    }
    public void Use(int n)
    {
        if (!canUse)
            return;
        npc.GetItem(items[n].itemCode);
        items[n].Use();
        items.Remove(items[n]);
        slots[n].GetComponent<Image>().sprite = slotbase;
    }
}
