using UnityEngine;

public class PlayerDefenseState : IStateMachine
{
    Player _player;
    public PlayerDefenseState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        throw new System.NotImplementedException();
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
        if (Input.GetButton("Fire2"))
        {
            _player.Animator.Play("Defend");
        }
    }
}
