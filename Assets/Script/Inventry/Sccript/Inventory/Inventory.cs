using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : InstanceSystem<Inventory>
{
    [SerializeField] GameObject _inventory;
    [SerializeField] GameObject _itemSlots;
    [SerializeField] Text _moneyText;
    [SerializeField] int _money = 500; 
    ItemState[] _myItems;
    int _itemSlotCount;
    int[] _getItemIndex;

    public ItemState[] MyItems { get => _myItems; set => _myItems = value; }
    public int ItemSlotCount { get => _itemSlotCount; }
    public int Money { get => _money; set => _money = value; }

    private void Awake()
    {
        _itemSlotCount = _itemSlots.transform.childCount;
        _myItems = new ItemState[_itemSlotCount];
        List<ItemState> itemList = new List<ItemState>(Resources.Load<ItemData>("ItemBase").Item);
        for(int i = 0; i < ItemSlotCount; i++)
        {
            if(i < itemList.Count)
            {
                if (itemList[i].ItemCount > 0)
                {
                    _myItems[i] = itemList[i];
                }
                else
                {
                    _myItems[i] = new ItemState(-1, default, 0, null);
                }
            }
            else
            {
                _myItems[i] = new ItemState(-1, default, 0, null);
            }
        }
        _inventory.SetActive(false);
    }
    private void OnEnable()
    {
        _money += FindObjectOfType<Player>().GetMoney;
        FindObjectOfType<Player>().GetMoney = 0;
        SetMoney();
        SetItem();
    }

    public void SetMoney()
    {
        _moneyText.text = $"${_money}";
    }
    public void SetItem()
    {
        for(int i = 0; i < _itemSlotCount; i++)
        {
            var viewItemParent = _itemSlots.transform.GetChild(i);
            var viewItem = viewItemParent.transform.GetChild(0).GetComponent<ItemButton>();
            if (_myItems[i].ItemID != -1)
            {
                viewItem.MyItem = _myItems[i];
            }
            else
            {
                viewItem.MyItem = new ItemState(-1, default, 0, null);
            }
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

    public void CloseMenu()
    {
        FindObjectOfType<Player>().State = Player.PLayerState.Game;
        FindObjectOfType<CinemachineFreeLook>().enabled = true;
    }
}
