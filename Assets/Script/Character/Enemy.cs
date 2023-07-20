using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : CharacterBase
{
    [SerializeField] GameObject _coin;
    [SerializeField] GameObject _attackObject;
    [SerializeField] int _coinCount;
    private void Update()
    {
        HpBar.value = HP;
        if (HP <= 0)
        {
            RemoveEnemy(this);
            for (int i = 0; i < _coinCount; i++)
            {
                Instantiate(_coin, transform.position, transform.rotation);
            }
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
