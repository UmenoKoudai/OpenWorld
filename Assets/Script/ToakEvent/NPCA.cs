using Cinemachine;
using UnityEngine;

public class NPCA : NPCBase
{
    [SerializeField] GameObject _nameTextObj;
    bool _isSpeak;

    private void Update()
    {
        if(_nameTextObj)
        {
            var lookForward = _nameTextObj.transform.position - SetUp().Player[0].transform.position;
            _nameTextObj.transform.forward = new Vector3(lookForward.x, 0, lookForward.z);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_isSpeak)
            {
                TalkStart();
            }
        }
        if(!_isSpeak)
        {
            TalkEnd();
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
