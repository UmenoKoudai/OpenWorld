public class DragonDiscoverState : IStateMachine
{
    Dragon _dragon;
    public DragonDiscoverState(Dragon dragon)
    {
        _dragon = dragon;
    }
    public void Enter()
    {
        _dragon.Animator.Play("Scream");
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
