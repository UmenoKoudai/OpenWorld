using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoDestroy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2);
    }
}
