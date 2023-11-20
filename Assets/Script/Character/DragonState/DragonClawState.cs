public class DragonClawState : IStateMachine
{
    Dragon _dragon;
    public DragonClawState(Dragon dragon)
    {
        _dragon = dragon;
    }
    public void Enter()
    {
        _dragon.Animator.Play("Claw Attack");
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
