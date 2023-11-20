public class DragonBlessState : IStateMachine
{
    Dragon _dragon;
    public DragonBlessState(Dragon dragon)
    {
        _dragon = dragon;
    }
    public void Enter()
    {
        _dragon.Animator.Play("Flame Attack");
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
