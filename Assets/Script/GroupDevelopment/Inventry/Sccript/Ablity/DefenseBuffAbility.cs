using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseBuffAbility :IAbility
{
    [SerializeField] int _buff;
    public void Use(Evaluator evl)
    {
        evl.Player.EffectInstance(CharacterBase.EffectPoint.Under, (GameObject)Resources.Load("DefenseBuffEffect"));
        evl.Player.DefenseBuff(_buff);
    }
}
