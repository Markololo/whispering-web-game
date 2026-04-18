using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

    public StateMachine StateMachine {  get; private set; }
    public UnityEngine.AI.NavMeshAgent Agent { get; private set; }
    public AIAnimationController aiAnimationController { get; private set; }

    public Transform[] Waypoints;
    public Transform Player;

    public float AttackRange = 2f;
    public LayerMask PlayerLayer;
    public StateType currentState;

    //Vision Settings
    public float viewDistance = 10f;
    public float viewAngle = 180f;
    public float eyeHeight = 1.0f;
    public LayerMask obstacleMask;
    public LayerMask playerMask;

    public float visionPersistence = 0.5f;
    private float lastSeenTime = -999f;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        aiAnimationController = GetComponent<AIAnimationController>();
        source = GetComponent<AudioSource>();
        StateMachine = new StateMachine();
        StateMachine.AddState(new IdlseState(this));
        StateMachine.AddState(new PatrolState(this));
        StateMachine.AddState(new ChaseState(this));
        StateMachine.AddState(new AttackState(this));

        StateMachine.TransitionToState(StateType.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.Update();
        currentState = StateMachine.GetCurrentStateType();
    }
    public AudioClip spiderPresence;
    public bool CanSeePlayer()
    {
        if (Player == null)
        {
            return false;
        }

        Vector3 eyePosition = transform.position + Vector3.up * eyeHeight;
        Vector3 targetPosition = Player.position + Vector3.up * 0.5f;
        Vector3 directionToPlayer = (targetPosition - eyePosition).normalized;
        float distanceToPlayer = Vector3.Distance(eyePosition, targetPosition);
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        // Check field of view
        if (angleToPlayer > viewAngle / 2f)
        {
            return Time.time - lastSeenTime < visionPersistence;
        }

        // Check distance
        if (distanceToPlayer > viewDistance)
        {
            return Time.time - lastSeenTime < visionPersistence;
        }

        // Perform raycast
        if (Physics.Raycast(eyePosition, directionToPlayer, out RaycastHit hit, viewDistance))
        {
            // If hit the player
            if (hit.transform == Player)
            {
                lastSeenTime = Time.time;
                return true;
            }
        }


        // If recently seen, still count as visible
        bool recentlySeen = Time.time - lastSeenTime < visionPersistence;
        if (recentlySeen)
        {
            source.clip = spiderPresence;
            source.PlayOneShot(spiderPresence);
        }
        return recentlySeen;
    }
    public AudioClip spiderAttack;
    public bool IsPlayerInAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if(distanceToPlayer <= AttackRange)
        {
            source.clip = spiderAttack;
            source.PlayOneShot(spiderAttack);
        }
        return distanceToPlayer <= AttackRange;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2f, 0) * transform.forward;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2f, 0) * transform.forward;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary * viewDistance);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary * viewDistance);
    }

}
