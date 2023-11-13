using UnityEngine;
using static CharacterBase;

public class PlayerMenuOpenState : IStateMachine
{
    Player _player;
    bool _isOpen;
    public PlayerMenuOpenState(Player player)
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!_isOpen)
            {
                _player.PlayerCamera.enabled = false;
                //_player.State = PLayerState.MenuOpen;
                _player.Menu.SetActive(true);
                _isOpen = true;
            }
            else
            {
                _player.PlayerCamera.enabled = true;
                //_player.State = PLayerState.MenuOpen;
                _player.Menu.SetActive(false);
                _isOpen = false;
            }
        }
    }
}
