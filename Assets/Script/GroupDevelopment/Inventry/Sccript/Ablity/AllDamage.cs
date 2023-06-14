using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDamage : IAbility
{
    [SerializeField] int _damage;
    public void Use(Evaluator evl)
    {
        evl.Enemy.ForEach(e => Debug.Log($"{e.name}‚É{_damage}ƒ_ƒ[ƒW"));
        evl.Enemy.ForEach(e => e.EffectInstance(CharacterBase.EffectPoint.Top, (GameObject)Resources.Load("LightningEffect")));
        evl.Enemy.ForEach(e => e.Damage(_damage));
    }
}
