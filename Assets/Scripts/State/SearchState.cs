using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : MonoBehaviour
{

    private SpiderController spiderController;

    private float searchTimer;
    private float searchDuration = 5f;
    private Quaternion startRotation;
    private float searchAngle = 180f;

    // Start is called before the first frame update
    void Start()
    {
        searchTimer = 0f;
    }

    public SearchState(SpiderController spiderController)
    {
        this.spiderController = spiderController;
    }

    public void Enter()
    {
        spiderController.Agent.updateRotation = false;
    }

    public void Execute()
    {
        if (spiderController.CanSeePlayer())
        {
            spiderController.StateMachine.TransitionToState(StateType.Chase);
            return;
        }

        if (searchTimer >= searchDuration)
        {
            spiderController.StateMachine.TransitionToState(StateType.Patrol);
            return;
        }
        this.Search();
    }

    public void Exit()
    {
        spiderController.Agent.updateRotation = true;
    }

    private void Search()
    {
        //Make the spider look around for a few seconds

        searchTimer += Time.deltaTime;
        float angle = Mathf.Sin(searchTimer * 2f) * searchAngle;
        transform.rotation = Quaternion.Euler(0, startRotation.eulerAngles.y +  angle, 0);
    }
}
