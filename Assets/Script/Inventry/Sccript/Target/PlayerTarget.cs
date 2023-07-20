using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTarget : ITarget
{
    public void TargetSet(Evaluator evl)
    {
        evl.SetTarget(evl.Player);
        Debug.Log(evl.Target.Count);
    }
}
