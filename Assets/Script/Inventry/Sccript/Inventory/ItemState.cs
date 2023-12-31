using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemState
{
    [SerializeField, Tooltip("アイテムのID")] int _itemID;
    [SerializeField, Tooltip("アイテムの画像")] Sprite _itemImage = default;
    int _itemCount;
    [Space(10)]
    [Header("アイテムを使用するターゲットを設定する")]
    [SerializeField, SerializeReference, SubclassSelector]
    ITarget _target = default;
    [Space(10)]
    [Header("アイテムの使用条件を決める")]
    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition>_condition = new List<ICondition>();
    [Space(10)]
    [Header("アイテムの効果を決める")]
    [SerializeField, SerializeReference, SubclassSelector]
    IAbility _ability = default;

    public int ItemID { get => _itemID; }
    public Sprite ItemImage { get => _itemImage;}
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public IAbility Ability { get => _ability;}
    public List<ICondition> Condition { get => _condition; }
    public ITarget Target { get => _target;}

    public ItemState(int id, Sprite image, int count, IAbility ability)
    {
        _itemID = id;
        _itemImage = image;
        _itemCount = count;
        _ability = ability;
    }
}
