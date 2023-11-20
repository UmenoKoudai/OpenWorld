using UnityEngine;

public class DragonDefaultState : IStateMachine
{
    Player _player;
    Dragon _dragon;

    bool _isDiscover = false;
    float _timer = 0f;

    public DragonDefaultState(Player player, Dragon dragon)
    {
        _player = player;
        _dragon = dragon;
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
        float distance = Vector3.Distance(_player.transform.position, _dragon.transform.position);
        if(!_isDiscover && _dragon.DiscoverDistance < distance)
        {
            _isDiscover = true;
            _dragon.StateChange(Dragon.DragonState.Discover);
        }
        else
        {
            _isDiscover = false;
        }
        if (_isDiscover)
        {
            _timer += Time.deltaTime;
            if (_timer > _dragon.Interval)
            {
                _timer = 0f;
                if (distance < _dragon.MeleeDistance)
                {
                    _dragon.StateChange(Dragon.DragonState.Bite);
                }
                else
                {
                    var random = Random.Range(0, 3);
                    switch (random)
                    {
                        case 0:
                            _dragon.StateChange(Dragon.DragonState.Bite);
                            break;
                        case 1:
                            _dragon.StateChange(Dragon.DragonState.Bless);
                            break;
                    }
                }
            }
        }
    }
}
