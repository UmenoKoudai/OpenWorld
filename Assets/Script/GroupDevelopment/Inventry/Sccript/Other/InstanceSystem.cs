using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceSystem<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<T>();
                if (!_instance)
                {
                    Debug.LogWarning($"{typeof(T).Name}���A�^�b�`�����I�u�W�F�N�g�����݂��܂���");
                }
            }
            return _instance;
        }
    }
}
