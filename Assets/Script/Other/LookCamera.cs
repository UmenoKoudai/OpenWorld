using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookCamera : MonoBehaviour
{
    void Update()
    {
        if(Camera.main)
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
