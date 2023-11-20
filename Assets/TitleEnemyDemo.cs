using UnityEngine;
using Utils;

[RequireComponent(typeof(Rigidbody))]
public class TitleEnemyDemo : MonoBehaviour
{
    [SerializeField]
    float _radius = 5f;
    [SerializeField]
    float _speed = 3f;
    [SerializeField]
    float _switchDistance = 0.1f;

    Vector3 _randomPos;
    Rigidbody _rb;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        GizmosExtensions.DrawWireCircle(transform.position, _radius);
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _randomPos = _radius * Random.insideUnitCircle;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, new Vector3(_randomPos.x, 3f, _randomPos.y));
        if(distance <= _switchDistance)
        {
            _randomPos = _radius * Random.insideUnitCircle;
        }
        transform.forward = new Vector3(_randomPos.x, 0f, _randomPos.y);
        _rb.velocity = transform.forward * _speed;
    }
}
