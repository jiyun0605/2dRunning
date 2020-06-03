using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items;
    public GameObject[] slots;
    Stack<int> slotCnt = new Stack<int>();
    public Sprite slotbase;
    public bool canUse;
    NPC npc;
    private void Start()
    {
        for(int i=3;i>=0;i--)
        {
            slotCnt.Push(i);          
        }
        for(int i=0;i<items.Length;i++)
            items[i].itemCode = -1;
    }
    public bool AddItem(Item item)
    {
        if (slotCnt.Count<=0)
            return false;
        SoundManager.soundManager.SFXPlay(5);
        int n = slotCnt.Pop();
        items[n] = item;
        slots[n].GetComponent<Image>().sprite = item.itemSprite;
        return true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FieldItem")
        {
            FieldItem fieldItem = collision.gameObject.GetComponent<FieldItem>();
            if (AddItem(fieldItem.GetItem()))
            {
                fieldItem.DestroyItem();
            }
        }
        if (collision.gameObject.tag=="NPC")
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
        Debug.Log(n);
        if (!canUse| items[n].itemCode == -1)
        {
            return;
        }
        
         npc.GetItem(items[n].itemCode);
        slotCnt.Push(n);
        items[n].Use();
        items[n].itemCode = -1;
        slots[n].GetComponent<Image>().sprite = slotbase;
    }
}
