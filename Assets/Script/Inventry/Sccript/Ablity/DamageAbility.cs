using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAbility : IAbility
{
    [SerializeField] int _damage;
    public void Use(Evaluator evl)
    {
        CharacterBase enemy = default;
        float min = float.MaxValue;
        evl.Target.ForEach(t =>
        {
            float distance = Vector3.Distance(evl.PlayerObj.transform.position, t.transform.position);
            if (min > distance)
            {
                min = distance;
                enemy = t;
            }
        });
        enemy.EffectInstance(CharacterBase.EffectPoint.Top, (GameObject)Resources.Load("LightningEffect"));
        enemy.Damage(_damage);
    }
}
