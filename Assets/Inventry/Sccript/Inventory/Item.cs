using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int _itemID;

    public void Get()
    {
        for (int i = 0; i < Inventory.Instance.ItemSlotCount; i++)
        {
            var myItems = Inventory.Instance.MyItems;
            if (myItems[i].ItemID == -1)
            {
                myItems[i] = Resources.Load<ItemData>("ItemBase").Item[_itemID - 1];
                myItems[i].ItemCount++;
                Inventory.Instance.SetItem();
                break;
            }
            if (myItems[i].ItemID == _itemID && myItems[i].ItemCount < 99)
            {
                myItems[i].ItemCount++;
                Inventory.Instance.SetItem();
                break;
            }
        }
    }
}
