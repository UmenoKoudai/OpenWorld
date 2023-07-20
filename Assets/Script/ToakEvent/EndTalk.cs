using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTalk : IButton
{
    public void ButtonEffect(Evaluator evl)
    {
        evl.NpcBase.TextContent.text = evl.NpcBase.NowTalk;
        evl.NpcBase.NowIndex = 0;
        evl.TalkObj.GetComponent<NPCA>().Menu.SetActive(false);
        evl.TalkObj.GetComponent<NPCA>().Camera.enabled = true;
        evl.TalkObj.GetComponent<NPCA>().Shortcut.SetActive(true);
    }
}
