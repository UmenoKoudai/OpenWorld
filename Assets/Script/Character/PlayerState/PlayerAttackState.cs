using UnityEngine;

public class PlayerAttackState : IStateMachine
{
    Player _player;
    float _timer;
    bool _isAttack;
    int _count;
    public PlayerAttackState(Player player)
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
        if (_isAttack)
        {
            _timer += Time.deltaTime;
            if (_timer > _player.AttackInterval)
            {
                _isAttack = false;
                _timer = 0;
                _count = 0;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (_count == 0)
            {
                _player.Animator.Play("Attack01");
            }
            else
            {
                _player.Animator.Play("Attack02");
            }
            _isAttack = true;
            _count++;
        }
    }
}
