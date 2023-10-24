using System;
using UnityEngine;

[Serializable]
public class TalkDeck
{
    [SerializeField] string _name;
    [SerializeField] string _talk;
    [SerializeField] string _buttonName;
    [SerializeField, SerializeReference, SubclassSelector]
    IButton _buttonAbility;
    public string Name { get => _name; }
    public string Talk { get => _talk; }
    public string ButtonName { get => _buttonName; }
    public IButton ButtonAbility { get => _buttonAbility; }
}
