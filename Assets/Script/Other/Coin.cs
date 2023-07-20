using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    [SerializeField] int _money;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            Debug.Log($"{_money}Money‚ðGet‚µ‚½");
            player.GetMoney += _money;
            Destroy(gameObject);
        }
    }
}
