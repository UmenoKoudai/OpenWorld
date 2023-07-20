using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTarget : ITarget
{
    public void TargetSet(Evaluator evl)
    {
        evl.SetTarget(evl.Enemy);
    }
}
