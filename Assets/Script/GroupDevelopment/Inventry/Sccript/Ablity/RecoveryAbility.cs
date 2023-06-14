using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecoveryAbility : IAbility
{
    [SerializeField] int _recovery;
    public void Use(Evaluator evl)
    {
        evl.Player.EffectInstance(CharacterBase.EffectPoint.Middle, (GameObject)Resources.Load("HealEffect"));
        evl.Player.Recovery(_recovery);
    }
}
