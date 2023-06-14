using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TalkDeck
{
    [SerializeField] string _name;
    [SerializeField] string _talk;
    public string Name { get => _name; }
    public string Talk { get => _talk; }
}
