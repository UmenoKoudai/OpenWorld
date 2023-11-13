using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDestroyState : IStateMachine
{
    Enemy _enemy;
    Transform _player;
    NowQuest _quest;
    float _timer;
    bool _isDestroy;
    public EnemyDestroyState(Enemy enemy, Transform player, NowQuest quest)
    {
        _enemy = enemy;
        _player = player;
        _quest = quest;
    }
    public void Enter()
    {
        Debug.Log($"{3}:{Time.timeScale}");
        //var dir = _player.position - _enemy.transform.position;
        //_enemy.Rb.AddForce((-dir.normalized + Vector3.up * 10) * 5, ForceMode.Impulse);
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        var dir = _player.position - _enemy.transform.position;
        _enemy.Rb.AddForce((-dir.normalized + Vector3.up * 10) * 5, ForceMode.Impulse);
        _timer += Time.deltaTime;
        if(_timer > 0.2f)
        {
            _enemy.Destroy(_enemy.transform.position);
            _enemy.gameObject.SetActive(false);
            Object.Destroy(_enemy.gameObject, 0.5f);
        }
    }
}
