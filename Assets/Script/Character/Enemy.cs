using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : CharacterBase
{
    [SerializeField] GameObject _coin;
    [SerializeField] int _coinCount;
    Player _player;
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        
    }
    private void Update()
    {
        if (HP <= 0)
        {
            _player.Evaluator.RemoveEnemy(this);
            for (int i = 0; i < _coinCount; i++)
            {
                Instantiate(_coin, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
