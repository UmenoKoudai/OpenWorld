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
    Evaluator _evl = new Evaluator();
    Rigidbody _rb;
    float _h;
    float _v;

    public Evaluator Evaluator { get => _evl; }
    private void Awake()
    {
        _evl.SetPlayer(this);
        _rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _menu.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        var dirForward = Vector3.forward * _v + Vector3.right * _h;
        dirForward = Camera.main.transform.TransformDirection(dirForward);
        dirForward.y = 0;
        if (_h != 0 || _v != 0)
        {
            transform.forward = dirForward;
        }
        _rb.velocity = dirForward.normalized * _moveSpeed + _rb.velocity.y * Vector3.up; ;
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
}
