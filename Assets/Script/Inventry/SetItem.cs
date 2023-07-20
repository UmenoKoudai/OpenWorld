using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetItem : MonoBehaviour
{
    [SerializeField] Inventory _inventory;
    int _childCount;

    public Inventory Inventory { get { return _inventory; } }
    void Start()
    {
        _childCount = transform.childCount;
    }
    private void OnEnable()
    {
        Set();
    }
    public void Set()
    {
        for(int i = 0; i < _childCount; i++)
        {
            var Shortcut =  transform.GetChild(i).GetComponentInChildren<ShortcutButton>();
            if(_inventory.MyItems[i] != null)
            {
                Shortcut.MyState = _inventory.MyItems[i];
            }
        }
    }
}
