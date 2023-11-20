public class DragonDestroyState : IStateMachine
{
    Dragon _dragon;
    public DragonDestroyState(Dragon dragon)
    {
        _dragon = dragon;
    }
    public void Enter()
    {
        _dragon.Animator.Play("Die");
        _dragon.Quest.TargetEnemyDestroy(IEnemyEnum.EnemyType.Dragon);
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
