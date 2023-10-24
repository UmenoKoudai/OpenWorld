using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    [SerializeField] int _money;
    public int Money => _money;

    public void GetCoin()
    {
        Destroy(gameObject);
    }
}
