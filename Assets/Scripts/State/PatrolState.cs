using UnityEngine;
using System.Collections;

public class PatrolState : IState
{
    private SpiderController spiderController;
    private int currentWaypointIndex = 0;
    private bool isWaiting = false;

    public StateType Type => StateType.Patrol;

    public PatrolState(SpiderController spiderController)
    {
        this.spiderController = spiderController;
    }

    public void Enter()
    {
        spiderController.Agent.isStopped = false;
        MoveToNextWaypoint();
    }

    public void Execute()
    {
        if (spiderController.CanSeePlayer())
        {
            spiderController.StateMachine.TransitionToState(StateType.Chase);
            return;
        }

        if (!isWaiting && !spiderController.Agent.pathPending && spiderController.Agent.remainingDistance <= spiderController.Agent.stoppingDistance)
        {
            spiderController.StartCoroutine(WaitAndAnimate());
        }
    }

    public void Exit()
    {
        spiderController.Agent.isStopped = false;
    }

    private IEnumerator WaitAndAnimate()
    {
        isWaiting = true;
        spiderController.Agent.isStopped = true;

        // Wait for animation duration (1.5 sec here, adjust to your animation length)
        yield return new WaitForSeconds(5);

        spiderController.Agent.isStopped = false;
        MoveToNextWaypoint();
        isWaiting = false;
    }

    private void MoveToNextWaypoint()
    {
        if (spiderController.Waypoints.Length == 0)
        {
            return;
        }

        spiderController.Agent.destination = spiderController.Waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % spiderController.Waypoints.Length;
    }

}
