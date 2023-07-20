using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;
using System;

public class BehaviourTreeRunner : MonoBehaviour
{
    [SerializeField] private BehaviourTree _behaviour;
    [SerializeField] private Animator _conditionAnim;
    private Environment _env = new();
    private BehaviourTree _cloneBehaviour;
    private int _nodeCount;
    private void Start()
    {
        _cloneBehaviour = BehaviorLoadManager.CloneBehaviorTree(_behaviour, gameObject.name);
        EnvSetUp();
    }

    private void Update()
    {
        _cloneBehaviour.update(_env);
    }

    /// <summary>
    /// behaviorTreeÇ…ìnÇ∑èÓïÒÇSetÇ∑ÇÈ
    /// </summary>
    public void EnvSetUp()
    {
        _env.mySelf = this.gameObject;
        _env.MySelfAnim = _conditionAnim;
        _env.navMesh = GetComponent<NavMeshAgent>();
        _env.ConditionAnim = _conditionAnim;
        _env.target = ActorGenerator.PlayerObj;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _cloneBehaviour.Nodes.Count; i++) 
        {
            _cloneBehaviour.Nodes[i].Cancel();
        }
    }

}
