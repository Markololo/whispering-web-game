using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlseState : IState
{
    private SpiderController spiderController;
    private float idleDuration = 60f;
    private float idleTimer;

    public StateType Type => StateType.Idle;

    public IdlseState(SpiderController spiderController)
    {
        this.spiderController = spiderController;
    }

    public void Enter()
    {
        idleTimer = 0f;
        //aiController.Animator.SetBool("isMoving", false);
        spiderController.Agent.isStopped = true;
    }

    public void Execute()
    {
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration)
        {
            spiderController.StateMachine.TransitionToState(StateType.Patrol);
        }

        if (spiderController.CanSeePlayer())
        {
            spiderController.StateMachine.TransitionToState(StateType.Chase);
            return;
        }
    }
    public void Exit()
    {
    }
}

