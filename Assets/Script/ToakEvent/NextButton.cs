using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : IButton
{
    public void ButtonEffect(Evaluator evl)
    {
        evl.NpcBase.TextContent.text = evl.NpcBase.NowTalk;
    }
}
