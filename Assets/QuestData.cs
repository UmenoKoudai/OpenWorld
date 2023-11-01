using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static IEnemyEnum;

[CreateAssetMenu(fileName = "QuestData", menuName = "QuestData")]
public class QuestData : ScriptableObject
{
    [SerializeField]
    List<Data> _questData = new List<Data>();

    public List<Data> Quest => _questData;
}

[Serializable]
public class Data
{
    [SerializeField]
    EnemyType _enemyType;
    public EnemyType Type => _enemyType;

    [SerializeField]
    string _content;
    public string Content => _content;

    [SerializeField]
    int _clearCount;
    public int ClearCount => _clearCount;

    [SerializeField]
    Image _questImage;
    public Image QuestImage => _questImage;

    bool _isClear;
    public bool IsClear => _isClear;
}
