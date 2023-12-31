using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static IEnemyEnum;

public class NowQuest : MonoBehaviour
{
    [SerializeField]
    Text _content;
    [SerializeField]
    Text _enemyDownCount;
    [SerializeField]
    QuestData _data;
    [SerializeField]
    GameObject _questPanel;
    [SerializeField]
    GameObject _questCardPrefab;
    [SerializeField]
    Image _questImage;

    int _questCount;

    List<Data> _questData = new List<Data>();
    Data _selectData = null;
    public Data SelectData { get => _selectData; set => _selectData = value; }

    public event Action OnClear;

    private void OnEnable()
    {
        _questData = _data.Quest;
        SetQuestCard();
    }

    void Update()
    {
        if (_selectData != null) 
        {
            if (_questCount == _selectData.ClearCount)
            {
                OnClear?.Invoke();
                Reset();
            }
            _content.text = _selectData.Content;
            _questImage.sprite = _selectData.QuestImage;
            _enemyDownCount.text = $"{_questCount}/{_selectData.ClearCount}";
        }
        else
        {
            _content.text = "NoQuest";
            _enemyDownCount.text = $"0/0";
        }
    }

    public void TargetEnemyDestroy(EnemyType target)
    {
        if (_selectData != null)
        {
            if (target == _selectData.Type && _questCount <= _selectData.ClearCount)
            {
                _questCount++;
            }
        }
    }

    public void SetQuestCard()
    {
        foreach (Data data in _questData) 
        {
            var questCard = Instantiate(_questCardPrefab, transform.position, transform.rotation);
            questCard.transform.SetParent(_questPanel.transform);
            questCard.GetComponent<QuestCard>().QuestData = data;
        }
    }

    public void SetQuestData(Data selectQuest)
    {
        _selectData = selectQuest;
    }
    private void Reset()
    {
        _selectData = null;
    }
}
