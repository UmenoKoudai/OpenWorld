using UnityEngine;

public class PlayerMoveState : IStateMachine
{
    Player _player;
    float _h;
    float _v;
    public PlayerMoveState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        _player.Animator.SetBool("IsDie", false);
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        var dirForward = Vector3.forward * _v + Vector3.right * _h;
        dirForward = Camera.main.transform.TransformDirection(dirForward);
        dirForward.y = 0;
        if (_h != 0 || _v != 0)
        {
            _player.transform.forward = dirForward;
        }
        _player.Rb.velocity = dirForward.normalized * _player.MoveSpeed + _player.Rb.velocity.y * Vector3.up;
    }

    public void Update()
    {
        _player.HpBar.value = _player.HP;
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        _player.Animator.SetFloat("Speed", _player.Rb.velocity.magnitude);
        Ray ray = new Ray(_player.transform.position, _player.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit, _player.RayRange, _player.HitLayer))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (hit.collider.gameObject.GetComponent<NPCBase>())
                {
                    hit.collider.gameObject.GetComponent<NPCBase>().ButtonAbility(hit.collider.gameObject.name);
                }
            }
        }
        if(_player.HP <= 0)
        {
            _player.StateChange(Player.PlayerState.Destroy);
        }
    }
}
