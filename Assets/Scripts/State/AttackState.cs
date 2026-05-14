// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class AttackState : IState
// {
//     private SpiderController spiderController;
//     private float attackCooldown = 1.5f; // seconds between attacks
//     private float lastAttackTime = -999f;

//     public StateType Type => StateType.Attack;

//     public AttackState(SpiderController spiderController)
//     {
//         this.spiderController = spiderController;
//     }

//     public void Enter()
//     {
//         spiderController.Agent.isStopped = true;
//         spiderController.aiAnimationController.HitPlayer();
//     }

//     public void Execute()
//     {
//         // If player moves out of attack range, go back to chase
//         if (Vector3.Distance(spiderController.transform.position, spiderController.Player.position) > spiderController.AttackRange)
//         {
//             spiderController.StateMachine.TransitionToState(StateType.Chase);
//             return;
//         }

//         // Limit how often the AI attacks
//         if (Time.time - lastAttackTime > attackCooldown)
//         {
//             lastAttackTime = Time.time;
//             //spiderController.aiAnimationController.animator.SetTrigger("doAttack");
//         }
//     }

//     public void Exit()
//     {
//         spiderController.Agent.isStopped = false;
//     }

// }
using UnityEngine;

public class AttackState : IState
{
    private SpiderController spiderController;

    private float attackCooldown = 1.5f;
    private float attackTimer;

    public StateType Type => StateType.Attack;

    public AttackState(SpiderController spiderController)
    {
        this.spiderController = spiderController;
    }

    public void Enter()
    {
        spiderController.Agent.isStopped = true;

        attackTimer = attackCooldown;

        spiderController.aiAnimationController.PlayAttack();
    }

    public void Execute()
    {
        if (!spiderController.IsPlayerInAttackRange())
        {
            spiderController.StateMachine.TransitionToState(StateType.Chase);
            return;
        }

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0f;

            spiderController.aiAnimationController.PlayAttack();
        }
    }

    public void Exit()
    {
        spiderController.Agent.isStopped = false;
    }
}