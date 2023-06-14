using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorHelper : MonoBehaviour
{
    private static bool _isCast = false;
    private static Transform _transform;
    private static float _radius;
    private static Vector3 _direction;
    private RaycastHit _hit;
    private static float _maxDistance;
    [SerializeField] private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void OnDrawSphere(Transform mySelf, float radius, Vector3 direction, float maxDistance)
    {
        _transform = mySelf.transform;
        _radius = radius;
        _direction = direction;
        _maxDistance = maxDistance;
        _isCast = true;
    }

    public static void StopDrawGizmos() 
    {
        _isCast = false;
    }

    private void OnDrawGizmos()
    {
        if (!_isCast) return;
        //�U��������o��
        var isHit = Physics.SphereCast(_transform.position + _offset, _radius, _transform.forward, out _hit, _maxDistance);

        if (isHit)
        {
            Gizmos.DrawRay(_transform.position + _offset, _transform.forward * _hit.distance);
            Gizmos.DrawWireSphere(_transform.position + _offset + _transform.forward * (_hit.distance), _radius);
        }
        else
        {
            Debug.DrawRay(_transform.position + _offset, _transform.forward * _maxDistance,Color.red);
        }
    }
}
