using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluator
{
    CharacterBase _player;
    List<CharacterBase> _enemyList;

    public CharacterBase Player { get => _player; }
    public List<CharacterBase> Enemy { get => _enemyList; }

    public void SetPlayer(CharacterBase player)
    {
        _player = player;
    }

    public void SetEnemy(CharacterBase enemy)
    {
        _enemyList.Add(enemy);
    }

    public void RemoveEnemy(CharacterBase enemy)
    {
        _enemyList.Remove(enemy);
    }
}
