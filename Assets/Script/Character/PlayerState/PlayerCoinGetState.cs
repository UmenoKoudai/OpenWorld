using UnityEngine;

public class PlayerCoinGetState : IStateMachine
{
    Player _player;
    public PlayerCoinGetState(Player player)
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
        foreach (var c in _player.Coins)
        {
            float distance = Vector3.Distance(_player.transform.position, c.transform.position);
            if (distance > _player.CoinDistance)
            {
                c.GetComponent<Rigidbody>().velocity = (_player.transform.position - c.transform.position) * 2f;
            }
            else
            {
                _player.GetMoney += c.Money;
                _player.Coins.Remove(c);
                c.GetCoin();
            }
        }
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
