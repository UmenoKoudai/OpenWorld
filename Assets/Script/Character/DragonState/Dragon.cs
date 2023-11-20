using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dragon : CharacterBase
{
    [SerializeField, Tooltip("ƒvƒŒƒCƒ„[‚ð”­Œ©‚·‚é‹——£"), Range(0, 101)]
    float _discoverDistance;
    public float DiscoverDistance => _discoverDistance;

    [SerializeField, Tooltip("‹ßÚUŒ‚‚ÉØ‚è‘Ö‚¦‚é‹——£"), Range(0, 101)]
    float _meleeDistance;
    public float MeleeDistance => _meleeDistance;

    [SerializeField, Tooltip("UŒ‚‚ÌŠÔŠu")]
    float _interval = 0.5f;
    public float Interval => _interval;

    [SerializeField]
    NowQuest _quest;
    public NowQuest Quest => _quest;

    Animator _animator;
    public Animator Animator => _animator;

    DragonState _state = DragonState.Default;
    public DragonState State
    {
        get => _state;
        set
        {
            switch (_state)
            {
                case DragonState.Default:
                    break;
                case DragonState.Discover:
                    _discover.Enter();
                    break;
                case DragonState.Bite:
                    _bite.Enter();
                    break;
                case DragonState.Bless:
                    _bless.Enter();
                    break;
                case DragonState.Claw:
                    _claw.Enter();
                    break;
                case DragonState.Destroy:
                    _destroy.Enter();
                    break;
            }
            _state = value;
        }
    }
    //DragonState _next = DragonState.Default;
    Player _player;

    DragonDefaultState _default;
    DragonBiteState _bite;
    DragonBlessState _bless;
    DragonClawState _claw;
    DragonDiscoverState _discover;
    DragonDestroyState _destroy;
   

    public enum DragonState
    {
        Default,
        Bite,
        Discover,
        Bless,
        Claw,
        Destroy,
    }


    void Start()
    {
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _default = new DragonDefaultState(_player, this);
        _bite = new DragonBiteState(this);
        _bless = new DragonBlessState(this);
        _discover = new DragonDiscoverState(this);
        _claw = new DragonClawState(this);
        _destroy = new DragonDestroyState(this);
    }

    void Update()
    {
        switch(_state)
        {
            case DragonState.Default:
                _default.Update();
                break;
            case DragonState.Discover:
                break;
            case DragonState.Bite:
                break;
            case DragonState.Bless:
                break;
            case DragonState.Claw:
                break;
            case DragonState.Destroy:
                break;
        }
    }

    public void BiteStart()
    {

    }

    public void BlessStart() 
    {

    }

    public void AnimationEnd()
    {
        StateChange(DragonState.Default);
    }

    public void StateChange(DragonState change)
    {
        State = change;
    }

    public void EnemyDestroy()
    {
        Destroy(gameObject, 0.2f);
    }
}
