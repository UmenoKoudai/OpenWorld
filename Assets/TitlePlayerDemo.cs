using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePlayerDemo : MonoBehaviour
{
    [SerializeField]
    float _speed;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.velocity = transform.forward * _speed;
    }
}
