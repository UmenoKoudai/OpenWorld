using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterBase : Evaluator
{
    [SerializeField] string _name;
    [SerializeField] int _maxHp;
    [SerializeField] int _attack;
    [SerializeField] int _defense;
    [SerializeField] Transform _topEffectPoint;
    [SerializeField] Transform _middleEffectPoint;
    [SerializeField] Transform _underEffectPoint;
    [SerializeField] Slider _hpBar;
    PLayerState _state = PLayerState.Game;
    int _hp = 0;

    public int HP { get => _hp; set => _hp = value; }
    public int Attack { get => _attack; set => _attack = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public Transform TopEffectPoint { get => _topEffectPoint; }
    public Transform MiddleEffect { get => _middleEffectPoint; }
    public Transform UnderEffect { get => _underEffectPoint; }
    public Slider HpBar { get => _hpBar; set => _hpBar = value; }
    public PLayerState State { get => _state; set => _state = value; }
    private void Start()
    {
        _hpBar.maxValue = _maxHp;
        _hp = _maxHp;
    }
    public void EffectInstance(EffectPoint point, GameObject effect)
    {
        Transform effectPoint;
        switch(point)
        {
            case EffectPoint.Top:
                effectPoint = _topEffectPoint;
                break;
            case EffectPoint.Middle:
                effectPoint = _middleEffectPoint;
                break;
            case EffectPoint.Under:
                effectPoint = _underEffectPoint;
                break;
            default:
                effectPoint = null; 
                break;
        }
        if (effectPoint)
        {
            Instantiate(effect, effectPoint.position, transform.rotation);
        }
    }
    public void Damage(int damage)
    {
        Debug.Log($"{gameObject.name}Ç…{damage}É_ÉÅÅ[ÉW");
        _hp -= damage;
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
    public enum EffectPoint
    {
        Top,
        Middle,
        Under,
    }
    public enum PLayerState
    {
        None,
        Game,
        MenuOpen,
    }
}