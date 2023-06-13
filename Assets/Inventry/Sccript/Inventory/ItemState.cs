using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemState
{
    [SerializeField, Tooltip("�A�C�e����ID")] int _itemID;
    [SerializeField, Tooltip("�A�C�e���̉摜")] Sprite _itemImage = default;
    int _itemCount;

    [Header("�A�C�e���̎g�p���������߂�")]
    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition>_condition = new List<ICondition>();
    [Header("�A�C�e���̌��ʂ����߂�")]
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
