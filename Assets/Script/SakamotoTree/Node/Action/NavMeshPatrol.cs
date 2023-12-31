using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NavMeshPatrol : ActionNode
{
    [Header("徘徊する範囲")]
    [SerializeField] private float _patrolRange = 0;
    [Header("目的地に着いたときに止まる時間")]
    [SerializeField] private float _goalStopTime = 0;
    [SerializeField] private float _speed;
    [NonSerialized] private Vector3 _startPosition;
    [NonSerialized] private Vector3 _goalPosition;
    [NonSerialized] private float _countTime;

    protected override void OnExit(Environment env)
    {
        env.MySelfAnim.SetBool("Move", false);
    }

    protected override void OnStart(Environment env)
    {
        _startPosition = env.mySelf.transform.position;
        env.MySelfAnim.SetBool("Move", true);
        env.navMesh.speed = _speed;
        SelectPosition();
    }

    protected override State OnUpdate(Environment env)
    {
        if (env.mySelf.transform.position.x == _goalPosition.x && env.mySelf.transform.position.z == _goalPosition.z
            && _countTime < _goalStopTime) 
        {
            //目的地に着いたら指定した秒数止まる
            _countTime += Time.deltaTime;
            env.MySelfAnim.SetBool("Move", false);
        }
        else if (env.mySelf.transform.position.x == _goalPosition.x && env.mySelf.transform.position.z == _goalPosition.z) 
        {
            //目的地変更
            env.MySelfAnim.SetBool("Move", true);
            SelectPosition();
            _countTime = 0;
        }
       
        env.navMesh.SetDestination(_goalPosition);
        return State.Running;
    }

    public void SelectPosition() 
    {
        _goalPosition.x = Random.Range(_startPosition.x - _patrolRange, _startPosition.x + _patrolRange);
        _goalPosition.y = _startPosition.y;
        _goalPosition.z = Random.Range(_startPosition.z - _patrolRange, _startPosition.z + _patrolRange);
    }
}