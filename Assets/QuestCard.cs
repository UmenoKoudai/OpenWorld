using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCard : MonoBehaviour
{
    [SerializeField]
    GameObject _questClearTag;
    [SerializeField]
    string _questContent;
    [SerializeField]
    Image _questImage;

    Data _questData;
    public Data QuestData { get => _questData; set => _questData = value; }
    void Start()
    {
        
    }

    void Update()
    {
        _questClearTag.SetActive(_questData.IsClear);
    }
}
