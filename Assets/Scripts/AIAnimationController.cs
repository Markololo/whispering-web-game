using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIAnimationController : MonoBehaviour
{
    //public Animator animator { get; private set; }
    private SpiderController spiderController;
    private NavMeshAgent agent;


    void Awake()
    {
        //animator = GetComponent<Animator>();
        spiderController = GetComponent<SpiderController>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Update animation parameters
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        float speed = agent != null ? agent.velocity.magnitude : 0f;

        //TODO: Uncomment animator code when added to project
        //animator.SetFloat("CharacterSpeed", speed);
    }

    void HitPlayer() // Attack Animation Event to check if the player his hit
    {
        GameObject objectHit;
        //Check collision with player here
    }

}
