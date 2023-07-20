using Cinemachine;
using UnityEngine;

public class NPCA : NPCBase
{
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _shortcutPanel;
    [SerializeField] CinemachineFreeLook _camera;
    Evaluator evl = new();
    Player _player;
    bool _isSpeak;
    int _index = 0;
    public GameObject Menu { get => _menu; set => _menu = value; }
    public GameObject Shortcut { get => _shortcutPanel; set => _shortcutPanel = value; }
    public CinemachineFreeLook Camera { get => _camera; set => _camera = value; }
    private void Update()
    {
        evl = SetUp();
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_isSpeak)
            {
                _camera.enabled = false;
                base.TextWindow.SetActive(true);
                PlayTalk();
            }
        }
        if(!_isSpeak)
        {
            base.TextWindow.SetActive(false);
            NowIndex = 0;
        }
    }
    void PlayTalk()
    {
        _index = NowIndex;
        if (_index >= TalkDeck.Count)
        {
            _index = 0;
            TextWindow.SetActive(false);
        }
        TalkDeck nowSpeak = TalkDeck[_index];
        NameText.text = nowSpeak.Name;
        NowName = nowSpeak.Name;
        NowTalk = nowSpeak.Talk;
        ButtonText.text = nowSpeak.ButtonName;
        SetTalkObj(gameObject, this);
        nowSpeak.ButtonAbility.ButtonEffect(SetUp());
        if (_index < TalkDeck.Count)
        {
            _index++;
        }
        NowIndex = _index;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            _isSpeak = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            _isSpeak = false;
        }
    }
}
