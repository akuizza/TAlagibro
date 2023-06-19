using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public enum MoveMode
{
    patrol, chase, wait
}

[RequireComponent(typeof(NavMeshAgent))]
public class AI : MonoBehaviour
{
    public MoveMode moveMode;

    [Header("Steering")]
    public float patrolSpeed;
    public float chaseSpeed;
    public float maxTimeChasing;
    public float maxTimeWaiting;
    public float radiusHit;

    [Header("Field Of View")]
    public float viewRadius;
    public float viewAngle;
    public LayerMask obstacleMask;
    public LayerMask targetMask;

    [Header("Transform")]
    public Transform[] patrolPoint;
    public NavMeshAgent agent;
    public Transform currentTarget;

    Vector3 destination;
    int index_patrolpoint;
    float currentTimeChasing, currentTimeWaiting;
    bool isDetectTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (agent.stoppingDistance < 0.5f)
            agent.stoppingDistance = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveMode)
        {
            case MoveMode.patrol:
                Patroling();
                break;
            case MoveMode.chase:
                Chasing();
                break;
            case MoveMode.wait:
                Waiting();
                break;
        }

        FieldOfView();
    }

    void FieldOfView()
    {
        Collider[] range = Physics.OverlapSphere(transform.position, viewRadius, targetMask, QueryTriggerInteraction.Ignore);

        if(range.Length > 0)
        {
            currentTarget = range[0].transform;

            Vector3 direction = (currentTarget.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, direction) < viewAngle / 2)
            {
                float m_distance = Vector3.Distance(transform.position, currentTarget.position);

                if (!Physics.Raycast(transform.position, direction, m_distance, obstacleMask, QueryTriggerInteraction.Ignore))
                {
                    isDetectTarget = true;

                    if ( moveMode != MoveMode.chase)
                    {
                        SwitchMoveMode(MoveMode.chase);
                    }
                }
                else
                {
                    isDetectTarget = false;
                }
            }
            else
            {
                isDetectTarget = false;
            }
        }
        else
        {
            isDetectTarget = false;
        }
    }

    void Waiting()
    {
        

        if(currentTimeWaiting > maxTimeWaiting)
        {
            SwitchMoveMode(MoveMode.patrol);
        }
        else
        {
            currentTimeWaiting += Time.deltaTime;
        }
    }

    void Patroling()
    {
        agent.speed = patrolSpeed;
        

        if (agent.remainingDistance < agent.stoppingDistance)
        {
            SwitchMoveMode(MoveMode.wait);
        }
    }

    bool isHit;

    void Chasing()
    {
        agent.speed = chaseSpeed;
        agent.destination = currentTarget.position;

        Collider[] col = Physics.OverlapSphere(transform.position, radiusHit, targetMask, QueryTriggerInteraction.Ignore);

        if (col.Length > 0 && !isHit)
        {
            Debug.Log("Permainan berakhir");
            isHit = true;
        }

        if(currentTimeChasing > maxTimeChasing)
        {
            SwitchMoveMode(MoveMode.wait);
        }
        else if(!isDetectTarget)
        {
            currentTimeChasing += Time.deltaTime;
        }
    }

    void SwitchMoveMode(MoveMode m_moveMode)
    {
        switch (m_moveMode)
        {
            case MoveMode.patrol:

                int lastindex = index_patrolpoint;
                int newindex = Random.Range(0, patrolPoint.Length);

                if(lastindex == newindex)
                {
                    newindex = Random.Range(0, patrolPoint.Length);
                    Debug.Log("recalculate index");
                    return;
                }

                index_patrolpoint = newindex;
                agent.destination = destination = patrolPoint[index_patrolpoint].position;
                Debug.Log("change patrol to " + index_patrolpoint.ToString());

                break;
            case MoveMode.chase:
                currentTimeChasing = 0;
                break;
            case MoveMode.wait:
                agent.destination = transform.position;
                currentTimeWaiting = 0;
                break;
        }

        moveMode = m_moveMode;
        Debug.Log("change move mode to " + moveMode.ToString());
    }

    void OnDrawGizmos()
    {
        if (agent == null) return;

        Gizmos.DrawWireSphere(transform.position, agent.stoppingDistance);
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        if (currentTarget != null && isDetectTarget)
            Gizmos.DrawLine(transform.position, currentTarget.position);

        float halfFov = viewAngle / 2f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFov, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFov, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay(transform.position, leftRayDirection * viewRadius);
        Gizmos.DrawRay(transform.position, rightRayDirection * viewRadius);
    }
}
