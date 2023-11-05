using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTalk : IButton
{
    public void ButtonEffect(Evaluator evl)
    {
        evl.TarkStart();
    }
}
