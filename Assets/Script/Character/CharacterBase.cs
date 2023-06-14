using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _attack;
    [SerializeField] int _defense;
    int _hp;

    public int HP { get => _hp; set => _hp = value; }
    public int Attack { get => _attack; set => _attack = value; }
    public int Defense { get => _defense; set => _defense = value; }

    private void Awake()
    {
        _hp = _maxHp;
    }
    public void Damage(int damage)
    {
        Debug.Log($"{gameObject.name}Ç…{damage}É_ÉÅÅ[ÉW");
        _hp -= damage;
        if(_hp < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Recovery(int recovery)
    {
        if (_hp + recovery < _maxHp)
        {
            _hp += recovery;
        }
        else
        {
            _hp = _maxHp;
        }
    }

    public void AttackBuff(int attackBuff)
    {
        _attack += attackBuff;
    }

    public void AttackDeBuff(int attackDeBuff)
    {
        _attack += attackDeBuff;
    }

    public void DefenseBuff(int defenseBuff)
    {
        _attack += defenseBuff;
    }

    public void DefenseDeBuff(int defenseDeBuff)
    {
        _attack += defenseDeBuff;
    }
}