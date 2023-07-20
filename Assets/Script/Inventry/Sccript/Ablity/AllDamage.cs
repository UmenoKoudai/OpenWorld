using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDamage : IAbility
{
    [SerializeField] int _damage;
    public void Use(Evaluator evl)
    {
        evl.Target.ForEach(t => t.EffectInstance(CharacterBase.EffectPoint.Top, (GameObject)Resources.Load("LightningEffect")));
        evl.Target.ForEach(t => t.DefenseBuff(_damage));
    }
}
