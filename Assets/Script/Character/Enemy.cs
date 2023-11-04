using System;
using System.Collections.Generic;
using UnityEngine;
using static IEnemyEnum;

public class Enemy : CharacterBase
{
    [SerializeField] GameObject _coin;
    [SerializeField] GameObject _attackObject;
    [SerializeField, Range(0, 8)] int _coinCount;
    [SerializeField]
    EnemyType _enemyType;
    NowQuest _nowQuest;

    Vector3[] _coinPos =
    {
        new Vector3(1, 2, 1),
        new Vector3(-1, 2, 1),
        new Vector3(1, 2, -1),
        new Vector3(1, 2, 0),
        new Vector3(-1, 2, 0),
        new Vector3(0, 2, 1),
        new Vector3(0, 2, -1),
        new Vector3(-1, 2, -1),
    };
    private void OnEnable()
    {
        HpBar.maxValue = MaxHp;
        HP = MaxHp;
    }
    private void Start()
    {
        _nowQuest = FindObjectOfType<NowQuest>();
    }

    private void Update()
    {
        HpBar.value = HP;
        if (HP <= 0)
        {
            _nowQuest.TargetEnemyDestroy(_enemyType);
            RemoveEnemy(this);
            List<GameObject> coins = new List<GameObject>();
            int n = 0;
            for (int i = 0; i < _coinCount; i++)
            {
                coins.Add(Instantiate(_coin, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0))));
            }
            coins.ForEach(r =>
            {
                r.GetComponent<Rigidbody>().AddForce(_coinPos[n] * 2, ForceMode.Impulse);
                n++;
            });
            Destroy(gameObject);
        }
    }

    public void AttackStart()
    {
        _attackObject.SetActive(true);
    }
    public void AttackEnd()
    {
        _attackObject.SetActive(false);
    }
}
