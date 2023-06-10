using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemState
{
    [SerializeField] int _itemID = -1;
    [SerializeField] Sprite _itemImage = default;
    int _itemCount = 1;

    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition>_condition = new List<ICondition>();
    [SerializeField, SerializeReference, SubclassSelector]
    IAbility _ability = default;

    public int ItemID { get => _itemID; }
    public Sprite ItemImage { get => _itemImage;}
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public IAbility Ability { get => _ability;}
    public List<ICondition> Condition { get => _condition; }

    public ItemState(int id, Sprite image, int count, IAbility ability)
    {
        _itemID = id;
        _itemImage = image;
        _itemCount = count;
        _ability = ability;
    }
}
