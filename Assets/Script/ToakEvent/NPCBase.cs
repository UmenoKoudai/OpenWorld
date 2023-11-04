using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public abstract class NPCBase : Evaluator
{

    [SerializeField] GameObject _textWindow;
    public GameObject TextWindow { get => _textWindow; set => _textWindow = value; }

    [SerializeField] GameObject _menu;
    public GameObject Menu { get => _menu; set => _menu = value; }

    [SerializeField] GameObject _shortcutPanel;
    public GameObject Shortcut { get => _shortcutPanel; set => _shortcutPanel = value; }

    [SerializeField] Text _talkText;
    public Text TextContent { get => _talkText; set => _talkText = value; }

    TalkDeck _talkDeck; 
    public TalkDeck TalcDeck => _talkDeck;

    [SerializeField] List<TalkDeck> _talk = new List<TalkDeck>();
    [SerializeField] Text _buttonText;
    [SerializeField] Text _nameText;
    [SerializeField] CinemachineFreeLook _camera;
    int _index;

    void PlayTalk()
    {
        if (_index >= _talk.Count)
        {
            _index = 0;
            TextWindow.SetActive(false);
        }
        _talkDeck = _talk[_index];
        _buttonText.text = _talkDeck.ButtonName;
        SetTalkObj(this);
        _talkDeck.ButtonAbility.ButtonEffect(SetUp());
        if (_index < _talk.Count)
        {
            _index++;
        }
        if(_talkDeck.ButtonName == "EndTalk")
        {
            TalkEnd();
        }
    }

    public void TalkStart()
    {
        _camera.enabled = false;
        PlayTalk();
        _textWindow.SetActive(true);
    }
    public void TalkEnd()
    {
        _camera.enabled = true;
        _textWindow.SetActive(false);
        _index = 0;
    }
}
