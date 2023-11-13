using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDestroyState : IStateMachine
{
    Player _player;
    public PlayerDestroyState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        _player.Animator.SetBool("IsDie", true);
        _player.transform.position = _player.RespawnPoint.position;
        _player.StateChange(Player.PlayerState.Default);
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {

    }
}
