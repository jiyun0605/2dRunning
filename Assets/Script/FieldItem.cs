using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{

    public Item item;
    public SpriteRenderer sprite;

    private void Start()
    {
        SetItem(item);
    }
    public void SetItem(Item _item)
    {
        sprite = GetComponent<SpriteRenderer>();
        item.itemName = _item.itemName;
        item.itemSprite = _item.itemSprite;
        item.itemCode = _item.itemCode;
        sprite.sprite = item.itemSprite;
    }
    public Item GetItem()
    {
        return item;
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
    }

}
