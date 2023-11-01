using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowQuest : MonoBehaviour
{
    [SerializeField]
    string _content;
    [SerializeField]
    string _enemyDownCount;
    [SerializeField]
    QuestData _data;
    [SerializeField]
    GameObject _questPanel;
    [SerializeField]
    GameObject _questCardPrefab;
    [SerializeField]
    Image _questImage;

    List<Data> _questData = new List<Data>();
    Data _selectData = null;
    public Data SelectData { get => _selectData; set => _selectData = value; }

    private void Awake()
    {
        _questData = _data.Quest;
    }
    void Update()
    {
        if (_questData != null) 
        {
            _content = _selectData.Content;
            _questImage = _selectData.QuestImage;
        }
    }

    public void SetQuestCard()
    {
        foreach (Data data in _questData) 
        {
            var questCard = Instantiate(_questCardPrefab, _questPanel.transform.position, transform.rotation);
            questCard.GetComponent<QuestCard>().QuestData = data;
        }
    }

    public void SetQuestData(Data selectQuest)
    {

    }
}
