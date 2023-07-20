using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachBuffAbility : IAbility
{
    [SerializeField] int _buff;
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
        CharacterBase.EffectPoint effect = CharacterBase.EffectPoint.Under;
        GameObject obj = (GameObject)Resources.Load("AttackBuffEffect");
        target.EffectInstance(effect, obj);
        target.AttackBuff(_buff);
    }
}
