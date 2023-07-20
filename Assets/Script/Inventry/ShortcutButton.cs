using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShortcutButton : Evaluator
{
    [SerializeField] int _buttonNumber;
    ItemState _myItem;
    KeyCode _key;
    int i;
    public ItemState MyState { get => _myItem; set => _myItem = value; }
    private void Awake()
    {
        _myItem = new ItemState(-1, default, 0, null);
        switch (_buttonNumber)
        {
            case 1:
                _key = KeyCode.F1;
                break;
            case 2:
                _key = KeyCode.F2;
                break;
            case 3:
                _key = KeyCode.F3;
                break;
            case 4:
                _key = KeyCode.F4;
                break;
            case 5:
                _key = KeyCode.F5;
                break;
            case 6:
                _key = KeyCode.F6;
                break;
            case 7:
                _key = KeyCode.F7;
                break;
            case 8:
                _key = KeyCode.F8;
                break;
            case 9:
                _key = KeyCode.F9;
                break;
            case 10:
                _key = KeyCode.F10;
                break;
            case 11:
                _key = KeyCode.F11;
                break;
            case 12:
                _key = KeyCode.F12;
                break;
        }

    }

    private void Update()
    {
        GetComponent<Image>().sprite = _myItem.ItemImage;
        if(Input.GetKeyDown(_key))
        {
            i++;
            Evaluator evl = SetUp();
            if (_myItem.Ability != null)
            {
                _myItem.Target.TargetSet(evl);
                if (_myItem.Condition.All(x => x.Check(evl)))
                {
                    _myItem.Ability.Use(evl);
                    GetComponentInParent<SetItem>().Inventory.ItemCountDown(_myItem.ItemID);
                    if (_myItem.ItemCount <= 0)
                    {
                        _myItem = new ItemState(-1, default, 0, null);
                    }
                    //GetComponentInParent<SetItem>().Set();
                }
            }
        }
    }
}
