using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class NPCBase : Evaluator
{

    [SerializeField] 
    GameObject _textWindow;

    [SerializeField] 
    GameObject _menu;

    [SerializeField] 
    GameObject _shortcutPanel;

    [SerializeField] 
    Text _talkText;

    [SerializeField]
    Text _nameText;
    [SerializeField]
    CinemachineFreeLook _camera;
    [SerializeField] 
    List<TalkDeck> _talk = new List<TalkDeck>();
    int _index = 0;

    public void ButtonAbility(string name)
    {
        Debug.Log($"[{name}]Index:{_index}");
        if(_index == 0)
        {
            Instance.OnOpenMenu += OpenMenu;
            Instance.OnPlayTalk += PlayTalk;
            Instance.OnTarkStart += TalkStart;
            Instance.OnTalkEnd += TalkEnd;
        }
        var evl = SetUp();
        foreach(var button in _talk[_index].ButtonAbility)
        {
            //Debug.Log(button);
            button.ButtonEffect(evl);
        }
    }

    void PlayTalk()
    {
        _nameText.text = _talk[_index].Name;
        _talkText.text = _talk[_index].Talk;
        if (_index < _talk.Count)
        {
            _index++;
        }
    }

    public void TalkStart()
    {
        _camera.enabled = false;
        _textWindow.SetActive(true);
    }

    public void OpenMenu()
    {
        _menu.SetActive(true);
        _shortcutPanel.SetActive(false);
    }

    public void TalkEnd()
    {
        _camera.enabled = true;
        _textWindow.SetActive(false);
        _menu.SetActive(false);
        _shortcutPanel.SetActive(true);
        _index = 0;
        Instance.OnOpenMenu -= OpenMenu;
        Instance.OnPlayTalk -= PlayTalk;
        Instance.OnTarkStart -= TalkStart;
        Instance.OnTalkEnd -= TalkEnd;
    }
}

[Serializable]
public class TalkDeck
{
    [SerializeField]
    string _name;
    public string Name => _name;

    [SerializeField] 
    string _talk;
    public string Talk => _talk;

    [SerializeField, SerializeReference, SubclassSelector]
    List<IButton> _buttonAbility = new List<IButton>();
    public List<IButton> ButtonAbility => _buttonAbility; 
}
