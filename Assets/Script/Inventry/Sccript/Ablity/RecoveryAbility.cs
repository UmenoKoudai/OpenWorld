using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecoveryAbility : IAbility
{
    [SerializeField] int _recovery;
    public void Use(Evaluator evl)
    {
        CharacterBase target = default;
        float min = float.MaxValue;
        evl.Target.ForEach(t =>
        {
            float distance = Vector3.Distance(evl.PlayerObj.transform.position, t.transform.position);
            if (min > distance)
            {
                min = distance;
                target = t;
            }
        });
        target.EffectInstance(CharacterBase.EffectPoint.Middle, (GameObject)Resources.Load("HealEffect"));
        target.Recovery(_recovery);
    }
}
