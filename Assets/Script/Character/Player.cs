using Cinemachine;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : CharacterBase
{
    [SerializeField] 
    int _moveSpeed;
    public int MoveSpeed => _moveSpeed;
    [SerializeField] 
    GameObject _menu;
    public GameObject Menu => _menu;
    [SerializeField] 
    float _attackInterval;
    public float AttackInterval => _attackInterval;
    [SerializeField] 
    GameObject _attackObject;
    public GameObject AttackObject => _attackObject;
    [SerializeField] 
    Transform _respawnPoint;
    public Transform RespawnPoint => _respawnPoint;
    [SerializeField] 
    float _coinDistance;
    public float CoinDistance => _coinDistance;
    [SerializeField]
    float _rayRange = 1.0f;
    public float RayRange => _rayRange;
    [SerializeField]
    LayerMask _hitLayer;
    public LayerMask HitLayer => _hitLayer;
    [SerializeField]
    CinemachineFreeLook _playerCamera;
    public CinemachineFreeLook PlayerCamera => _playerCamera;

    Rigidbody _rb;
    public Rigidbody Rb => _rb;
    Animator _anim;
    public Animator Animator => _anim;
    List<Coin> _coins = new List<Coin>();
    public List<Coin> Coins => _coins;
    int _getMoney;
    public int GetMoney { get => _getMoney; set => _getMoney = value; }

    PlayerState _state = PlayerState.Default;
    PlayerState _nextState = PlayerState.Default;
    bool _timeBool;
    public bool TimeBool
    {
        get => _timeBool;
        set
        {
            float timer = 0f;
            while(timer < 10f)
            {

            }
        }
    }

    PlayerMoveState _move;
    PlayerAttackState _attack;
    PlayerDefenseState _defense;
    PlayerMenuOpenState _menuOpen;
    PlayerCoinGetState _coinGet;
    PlayerDestroyState _destroy;

    public enum PlayerState
    {
        Default,
        Destroy,
    }

    private void OnEnable()
    {
        HpBar.maxValue = MaxHp;
        HP = MaxHp;
        base.Awake();
        SetPlayer(this, gameObject);
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _move = new PlayerMoveState(this);
        _attack = new PlayerAttackState(this);
        _defense = new PlayerDefenseState(this);
        _menuOpen = new PlayerMenuOpenState(this);
        _coinGet = new PlayerCoinGetState(this);
        _destroy = new PlayerDestroyState(this);
    }

    void Update()
    {
        _coins = FindObjectsOfType<Coin>().ToList();
        if (State == PLayerState.Game)
        {
            switch (_state)
            {
                case PlayerState.Default:
                    _move.Update();
                    _attack.Update();
                    _defense.Update();
                    //_menuOpen.Update();
                    break;
                case PlayerState.Destroy:
                    break;
            }
            if(_state != _nextState)
            {
                switch (_nextState)
                {
                    case PlayerState.Default:
                        _move.Enter();
                        break;
                    case PlayerState.Destroy:
                        _destroy.Enter();
                        break;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (State == PLayerState.Game)
        {
            switch (_state)
            {
                case PlayerState.Default:
                    _move.FixedUpdate();
                    _coinGet.FixedUpdate();
                    break;
            }
        }
    }

    public void StateChange(PlayerState changeState)
    {
        _nextState = changeState;
    }

    public void AttackStart()
    {
        Instantiate((GameObject)Resources.Load("HitEffect"), _attackObject.transform.position, transform.rotation);
        _attackObject.SetActive(true);
    }

    public void AttackEnd()
    {
        _attackObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterBase enemy = other.GetComponent<CharacterBase>();
        if (enemy)
        {
            SetEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterBase enemy = other.GetComponent<CharacterBase>();
        if (enemy)
        {
            RemoveEnemy(enemy);
        }
    }
}
