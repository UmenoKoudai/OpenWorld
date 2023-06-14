using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCA : NPCBase
{
    Player _player;
    bool _isSpeak;
    int _index = 0;
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (_player.GetComponent<Player>().State == Player.PLayerState.Game)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (_isSpeak)
                {
                    base.TextWindow.SetActive(true);
                    Speak();
                }
            }
        }
    }
    void Speak()
    {
        if (_index >= base.Speak.Count)
        {
            _index = 0;
            base.TextWindow.SetActive(false);
        }
        TalkDeck nowSpeak = base.Speak[_index];
        base.NameText.text = nowSpeak.Name;
        StartCoroutine(TalkSystem(nowSpeak.Talk));
        if (_index < base.Speak.Count)
        {
            _index++;
        }
    }
    IEnumerator TalkSystem(string talks)
    {
        base.SpeakText.text = "";
        foreach (var talk in talks)
        {
            base.SpeakText.text += talk;
            yield return new WaitForSeconds(0.1f);
        }
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
