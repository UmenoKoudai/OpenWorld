using System;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using static IEnemyEnum;

public class Enemy : CharacterBase
{
    [SerializeField] 
    GameObject _attackObject;
    [SerializeField]
    EnemyType _enemyType;
    public EnemyType EnemyType => _enemyType;
    [SerializeField]
    int _getMoney;
    [SerializeField]
    GameObject _destroyEffect;
    public GameObject DestroyEffect => _destroyEffect;

    Rigidbody _rb;
    public Rigidbody Rb { get => _rb; set => _rb = value; }
    bool _isDestroy;

    NowQuest _nowQuest;
    EnemyMove _state = EnemyMove.None;
    EnemyMove _next = EnemyMove.None;
    EnemyDestroyState _destroy;
    EnemyHitStopState _hitStop;

    public enum EnemyMove
    {
        None,
        Destroy,
        HitStop,
    }

    private void OnEnable()
    {
        HpBar.maxValue = MaxHp;
        HP = MaxHp;
        _rb = GetComponent<Rigidbody>();
        _hitStop = new EnemyHitStopState(this);
        _destroy = new EnemyDestroyState(this, Instance.PlayerObj.transform, _nowQuest);
        Debug.Log(_destroy);
    }
    private void Start()
    {
        _nowQuest = FindObjectOfType<NowQuest>();
    }

    private void Update()
    {
        HpBar.value = HP;
        if (HP <= 0 && !_isDestroy)
        {
            _isDestroy = true;
            _nowQuest.TargetEnemyDestroy(_enemyType);
            GameManager.Instance.Money += _getMoney;
            RemoveEnemy(this);
            StateChange(EnemyMove.HitStop);
        }
        switch (_state)
        {
            case EnemyMove.Destroy:
                _destroy.Update();
                break;
            case EnemyMove.HitStop:
                _hitStop.Update();
                break;
        }
        if(_state != _next)
        {
            switch (_next)
            {
                case EnemyMove.Destroy:
                    _destroy.Enter();
                    break;
                case EnemyMove.HitStop:
                    _hitStop.Enter();
                    break;
            }
            _state = _next;
        }

    }

    public void StateChange(EnemyMove change)
    {
        _next = change;
    }

    public void AttackStart()
    {
        _attackObject.SetActive(true);
    }
    public void AttackEnd()
    {
        _attackObject.SetActive(false);
    }
    public void Destroy(Vector3 destroyPosition)
    {
        Instantiate(_destroyEffect, destroyPosition, Quaternion.identity);
    }
}
