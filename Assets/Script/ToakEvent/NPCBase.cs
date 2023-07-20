using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class NPCBase : Evaluator
{
    [SerializeField] List<TalkDeck> _talk = new List<TalkDeck>();
    [SerializeField] Text _talkText;
    [SerializeField] Text _nameText;
    [SerializeField] GameObject _textWindow;
    [SerializeField] Text _buttonText;
    string _nowTalk;
    string _nowName;
    int _nowIndex;
    public List<TalkDeck> TalkDeck { get => _talk; }
    public Text NameText { get => _nameText; set => _nameText = value;}
    public GameObject TextWindow { get => _textWindow; set => _textWindow = value; }
    public Text TextContent { get => _talkText; set => _talkText = value; }
    public Text ButtonText { get => _buttonText; set => _buttonText = value; }
    public string NowTalk { get => _nowTalk; set => _nowTalk = value; }
    public string NowName { get => _nowName; set => _nowName = value; }
    public int NowIndex { get => _nowIndex; set => _nowIndex = value; }
}
