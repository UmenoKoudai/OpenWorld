using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseBuffAbility :IAbility
{
    [SerializeField] int _buff;
    public void Use(Evaluator evl)
    {
        CharacterBase target = default;
        float min = float.MaxValue;
        for(int i = 0; i < evl.Target.Count; i++)
        {
            Debug.Log(evl.Target[i]);
            float distance = Vector3.Distance(evl.PlayerObj.transform.position, evl.Target[i].transform.position);
            if (min > distance)
            {
                min = distance;
                target = evl.Target[i];
            }
        }
        //Evaluator.Target.ForEach(t =>
        //{
        //    float distance = Vector3.Distance(Evaluator.PlayerObj.transform.position, t.transform.position);
        //    if (min > distance)
        //    {
        //        min = distance;
        //        target = t;
        //    }
        //});
        target.EffectInstance(CharacterBase.EffectPoint.Under, (GameObject)Resources.Load("DefenseBuffEffect"));
        target.DefenseBuff(_buff);
    }
}
