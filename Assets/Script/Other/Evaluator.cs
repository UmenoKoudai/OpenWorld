using System.Collections.Generic;
using UnityEngine;

public class Evaluator: MonoBehaviour
{
    static Evaluator _instance;
    public static Evaluator Instance => _instance;

    List<CharacterBase> _playerList = new List<CharacterBase>();
    List<CharacterBase> _enemyList = new List<CharacterBase>();
    List<CharacterBase>_target = new List<CharacterBase>();
    GameObject _playerObj;
    NPCBase _npcBase;

    public List<CharacterBase> Player { get => _playerList; set => _playerList = value;}
    public List<CharacterBase> Enemy { get => _enemyList; set => _enemyList = value; }
    public List<CharacterBase> Target { get => _target; set => _target = value; }
    public GameObject PlayerObj { get => _playerObj; set => _playerObj = value; }
    public NPCBase NpcBase { get => _npcBase; set => _npcBase = value; }

    protected void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }
    public Evaluator SetUp()
    {
        return _instance;
    }
    public void SetTarget(List<CharacterBase> target)
    {
        //_target.Clear();
        Evaluator.Instance.Target = target;
    }
    public void SetTalkObj(NPCBase npcBase)
    {
        Evaluator.Instance.NpcBase = npcBase;
    }
    public void SetPlayer(CharacterBase player, GameObject playerObj)
    {
        Evaluator.Instance.PlayerObj = playerObj;
        Evaluator.Instance.Player.Add(player);
    }

    public void SetEnemy(CharacterBase enemy)
    {
        Evaluator.Instance.Enemy.Add(enemy);
    }

    public void RemoveEnemy(CharacterBase enemy)
    {
        Evaluator.Instance.Enemy.Remove(enemy);
    }
}
