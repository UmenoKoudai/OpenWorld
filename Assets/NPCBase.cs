using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class NPCBase : MonoBehaviour
{
    [SerializeField] List<TalkDeck> _speak = new List<TalkDeck>();
    [SerializeField] Text _speakText;
    [SerializeField] Text _nameText;
    [SerializeField] GameObject _textWindow;
    public List<TalkDeck> Speak { get => _speak; }
    public Text SpeakText { get => _speakText; set => _speakText = value; }
    public Text NameText { get => _nameText; set => _nameText = value;}
    public GameObject TextWindow { get => _textWindow; set => _textWindow = value; }
}
