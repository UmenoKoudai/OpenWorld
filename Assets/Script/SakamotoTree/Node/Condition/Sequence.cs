using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Sequence : ConditionNode
{
    [NonSerialized] private int _count = 0;
    protected override void OnExit(Environment env)
    {

    }

    protected override void OnStart(Environment env)
    {

    }

    protected override State OnUpdate(Environment env)
    {
        _count = 0;
        
        while (NodeChildren.Count > _count)
        {
            State childState = NodeChildren[_count].update(env);
            if (childState == State.Success)
            {
                //Debug.Log(_count);
                //最後まで成功した場合成功を返す
                if (_count == NodeChildren.Count - 1)
                {
                    Debug.Log("すべて成功");
                    return State.Success;
                }
                _count++;
                continue;
            }
            return childState;
        }
        return State.Running;
    }
}
