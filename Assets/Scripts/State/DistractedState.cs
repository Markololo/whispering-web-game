using UnityEngine;

public class DistractedState : IState
{
    private SpiderController spiderController;

    public StateType Type => StateType.Distracted;

    public DistractedState(SpiderController spiderController)
    {
        this.spiderController = spiderController;
    }

    public void Enter()
    {
        spiderController.Agent.isStopped = false;
    }

    public void Execute()
    {
        if (!spiderController.CanSeeBait())
        {
            spiderController.StateMachine.TransitionToState(StateType.Patrol);
            return;
        }

        spiderController.Agent.destination = spiderController.nearestBait.position;
    }

    public void Exit()
    {
        // No cleanup necessary
    }

}


