using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOpenButton : IButton
{
    public void ButtonEffect(Evaluator evl)
    {
        evl.NpcBase.TextContent.text = evl.NpcBase.NowTalk;
        evl.TalkObj.GetComponent<NPCA>().Menu.SetActive(true);
        evl.TalkObj.GetComponent<NPCA>().Shortcut.SetActive(false);
    }
}
