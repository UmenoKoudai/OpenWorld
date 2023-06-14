using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : CharacterBase
{
    [SerializeField] int _moveSpeed;
    [SerializeField] GameObject _menu;
    [SerializeField] float _attackInterval;
    Evaluator _evl = new Evaluator();
    PLayerState _state = PLayerState.Game;
    Rigidbody _rb;
    Animator _anim;
    float _h;
    float _v;
    int _attackCount;
    bool _isAttack;
    float _timer;

    public Evaluator Evaluator { get => _evl; }
    public PLayerState State { get => _state; set => _state = value; }
    private void Awake()
    {
        _evl.SetPlayer(this);
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_state == PLayerState.Game)
        {
            _h = Input.GetAxisRaw("Horizontal");
            _v = Input.GetAxisRaw("Vertical");
            _anim.SetFloat("Speed", _rb.velocity.magnitude);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FindObjectOfType<CinemachineFreeLook>().enabled = false;
                _state = PLayerState.MenuOpen;
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
        }
    }
    private void FixedUpdate()
    {
        if (_state == PLayerState.Game)
        {
            var dirForward = Vector3.forward * _v + Vector3.right * _h;
            dirForward = Camera.main.transform.TransformDirection(dirForward);
            dirForward.y = 0;
            if (_h != 0 || _v != 0)
            {
                transform.forward = dirForward;
            }
            _rb.velocity = dirForward.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterBase enemy = other.GetComponent<CharacterBase>();
        if (enemy)
        {
            _evl.SetEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterBase enemy = other.GetComponent<CharacterBase>();
        if (enemy)
        {
            _evl.RemoveEnemy(enemy);
        }
    }
    public enum PLayerState
    {
        None,
        Game,
        MenuOpen,
    }
}
