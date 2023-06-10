using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : InstanceSystem<Inventory>
{
    [SerializeField] GameObject _inventory;
    ItemState[] _myItems;
    int _itemSlotCount;
    int[] _getItemIndex;

    public ItemState[] MyItems { get => _myItems; set => _myItems = value; }
    public int ItemSlotCount { get => _itemSlotCount; }

    private void Awake()
    {
        _itemSlotCount = _inventory.transform.childCount;
        _myItems = Enumerable.Repeat(new ItemState(-1, default, 1, null), ItemSlotCount).ToArray();
        //Load();
        SetItem();
        //_inventory.SetActive(false);
    }

    public void SetItem()
    {
        for(int i = 0; i < _itemSlotCount; i++)
        {
            var viewItemParent = _inventory.transform.GetChild(i);
            var viewItem = viewItemParent.transform.GetChild(0).GetComponent<ItemButton>();
            if (_myItems[i].ItemID != -1)
            {
                viewItem.MyItem = _myItems[i];
            }
            else
            {
                viewItem.MyItem = new ItemState(-1, default, 0, null);
            }
            //Save();
        }
    }

    public void ItemCountDown(int id)
    {
        for(int i = 0; i < _itemSlotCount; i++)
        {
            if (_myItems[i].ItemID == id)
            {
                if (_myItems[i].ItemCount > 0)
                {
                    _myItems[i].ItemCount--;
                    if (_myItems[i].ItemCount == 0)
                    {
                        _myItems[i] = new ItemState(-1, default, 0, null);
                        SetItem();
                    }
                    break;
                }
            }
        }
    }

    //void Save()
    //{
    //    _getItemIndex = new int[_myItems.Length * 2];
    //    int j = 0;
    //    for(int i = 0; i < _myItems.Length; i++)
    //    {
    //        if (_myItems[i].ItemID != -1)
    //        {
    //            _getItemIndex[j] = _myItems[i].ItemID;
    //            j++;
    //            _getItemIndex[j] = _myItems[i].ItemCount;
    //            j++;
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }
    //    _getItemIndex.OnSave();
    //}

    //void Load()
    //{
    //    int[] loadIndex = _getItemIndex.OnLoad();
    //    if (loadIndex != null)
    //    {
    //        int j = 0;
    //        for (int i = 0; i < loadIndex.Length / 2; i++)
    //        {
    //            if (loadIndex[j] != -1)
    //            {
    //                _myItems[i] = Resources.Load<ItemData>("ItemBase").Item[loadIndex[j] - 1];
    //                j++;
    //                _myItems[i].ItemCount = loadIndex[j];
    //                j++;
    //            }

    //            else
    //            {
    //                break;
    //            }
    //        }
    //    }
    //}
}
