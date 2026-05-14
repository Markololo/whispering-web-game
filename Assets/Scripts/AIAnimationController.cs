using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIAnimationController : MonoBehaviour
{
    //public Animator animator { get; private set; }
    private SpiderController spiderController;
    private NavMeshAgent agent;
    private Animator animator;
    private float attackTimer = 0f;
    private float attackCooldown = 2f;

public void Execute()
{
    // attackTimer += Time.deltaTime;

    // if (!spiderController.IsPlayerInAttackRange())
    // {
    //     spiderController.StateMachine.TransitionToState(StateType.Chase);
    //     return;
    // }

    // if (attackTimer >= attackCooldown)
    // {
    //     attackTimer = 0f;
    //     spiderController.aiAnimationController.PlayAttack();
    // }
}

    void Awake()
    {
        //animator = GetComponent<Animator>();
        spiderController = GetComponent<SpiderController>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Update animation parameters
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        float speed = agent != null ? agent.velocity.magnitude : 0f;

        animator.SetFloat("speed", speed);
    }

    void HitPlayer() // Attack Animation Event to check if the player his hit
    {
        GameObject objectHit;
        // animator.SetTrigger("attack");
        //Check collision with player here
    }
    
    public void PlayAttack()
    {
        animator.SetTrigger("attack");
    }

    public void PlayIdle()
    {
        animator.SetFloat("speed", 0f);
    }

    public void PlayWalk()
    {
        animator.SetFloat("speed", 1f);
    }

}
