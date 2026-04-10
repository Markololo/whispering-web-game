using UnityEngine;

public class ChaseState : IState
{
    private SpiderController spiderController;

    public StateType Type => StateType.Chase;

    public ChaseState(SpiderController spiderController)
    {
        this.spiderController = spiderController;
    }

    public void Enter()
    {
        // No animations, so no need to set any animator parameters
    }

    public void Execute()
    {
        if (!spiderController.CanSeePlayer())
        {
            spiderController.StateMachine.TransitionToState(StateType.Patrol);
            return;
        }

        if (spiderController.IsPlayerInAttackRange())
        {
            spiderController.StateMachine.TransitionToState(StateType.Attack);
            return;
        }

        spiderController.Agent.destination = spiderController.Player.position;
    }

    public void Exit()
    {
        // No cleanup necessary
    }

}


