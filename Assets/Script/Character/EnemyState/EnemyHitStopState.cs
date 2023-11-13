using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHitStopState : IStateMachine
{
    Enemy _enemy;
    float _timeScale;
    float _timer;
    bool _isHitStop = false;

    public EnemyHitStopState(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void Enter()
    {
        if (!_isHitStop)
        {
            _timeScale = Time.timeScale;
            Time.timeScale = 0;
            _isHitStop = true;
            Debug.Log($"{1}:{Time.timeScale}");
        }
    }

    public void Exit()
    {
        Time.timeScale = 1;
        Debug.Log($"{2}:{Time.timeScale}");
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer > 0.2f)
        {
            Exit();
            _enemy.StateChange(Enemy.EnemyMove.Destroy);
        }
    }
}
