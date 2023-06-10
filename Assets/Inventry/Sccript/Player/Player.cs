using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    Evaluator _evl = new Evaluator();

    public Evaluator Evaluator { get => _evl; }
    private void Awake()
    {
        _evl.SetPlayer(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterBase enemy = other.GetComponent<CharacterBase>();
        if (!enemy)
        {
            _evl.SetEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterBase enemy = other.GetComponent<CharacterBase>();
        if (!enemy)
        {
            _evl.RemoveEnemy(enemy);
        }
    }
}
