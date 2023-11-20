public class DragonBiteState : IStateMachine
{
    Dragon _dragon;
    public DragonBiteState(Dragon dragon)
    {
        _dragon = dragon;
    }
    public void Enter()
    {
        _dragon.Animator.Play("Basic Attack");
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
