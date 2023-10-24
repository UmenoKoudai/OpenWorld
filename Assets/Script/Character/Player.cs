using Cinemachine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : CharacterBase
{
    [SerializeField] int _moveSpeed;
    [SerializeField] GameObject _menu;
    [SerializeField] float _attackInterval;
    [SerializeField] GameObject _attackObject;
    [SerializeField] Transform _respawnPoint;
    [SerializeField] float _coinDistance;
    Rigidbody _rb;
    Animator _anim;
    public List<Coin> _coins = new List<Coin>();
    float _h;
    float _v;
    int _attackCount;
    bool _isAttack;
    float _timer;
    int _getMoney;

    public int GetMoney { get => _getMoney; set => _getMoney = value; }
    private void Awake()
    {
        base.Awake();
        SetPlayer(this, gameObject);
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        HpBar.value = HP;
        if (State == PLayerState.Game)
        {
            _coins = FindObjectsOfType<Coin>().ToList();
            _h = Input.GetAxisRaw("Horizontal");
            _v = Input.GetAxisRaw("Vertical");
            _anim.SetFloat("Speed", _rb.velocity.magnitude);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FindObjectOfType<CinemachineFreeLook>().enabled = false;
                State = PLayerState.MenuOpen;
                _menu.SetActive(true);
            }
            if (_isAttack)
            {
                _timer += Time.deltaTime;
                if (_timer > _attackInterval)
                {
                    _isAttack = false;
                    _timer = 0;
                    _attackCount = 0;
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if (_attackCount == 0)
                {
                    _anim.Play("Attack01");
                }
                else
                {
                    _anim.Play("Attack02");
                }
                _isAttack = true;
                _attackCount++;
            }
            if(Input.GetButton("Fire2"))
            {
                _anim.Play("Defend");
            }
            if(HP <= 0)
            {
                _anim.SetBool("IsDie", true);
                Respawn();
            }
        }
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
    public void Respawn()
    {
        _anim.SetBool("IsDie", false);
        transform.position = _respawnPoint.position;
    }
    private void FixedUpdate()
    {
        if (State == PLayerState.Game)
        {
            Debug.Log($"money {_getMoney}");
            var dirForward = Vector3.forward * _v + Vector3.right * _h;
            dirForward = Camera.main.transform.TransformDirection(dirForward);
            dirForward.y = 0;
            if (_h != 0 || _v != 0)
            {
                transform.forward = dirForward;
            }
            _rb.velocity = dirForward.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
            foreach (var c in _coins)
            {
                float distance = Vector3.Distance(transform.position, c.transform.position);
                if (distance > _coinDistance)
                {
                    c.GetComponent<Rigidbody>().velocity = (transform.position - c.transform.position) * 2f;
                }
                else
                {
                    _getMoney += c.Money;
                    _coins.Remove(c);
                    c.GetCoin();
                }
            }
        }
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
