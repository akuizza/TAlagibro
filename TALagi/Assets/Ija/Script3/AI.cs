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
    public float radiusHit;
    public LayerMask targetMask;

    [Header("Transform")]
    public Transform[] patrolPoint;
    public NavMeshAgent agent;
    public Transform currentTarget;

    Vector3 destination;
    int index_patrolpoint;
    float currentTimeChasing;

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
                break;
        }
    }

    void Patroling()
    {
        agent.speed = patrolSpeed;
        agent.destination = destination = patrolPoint[index_patrolpoint].position;

        if (agent.remainingDistance < agent.stoppingDistance)
        {
            index_patrolpoint = Random.Range(0, patrolPoint.Length);
            Debug.Log("Ubah patrol ke " + index_patrolpoint.ToString());
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
            moveMode = MoveMode.patrol;
            currentTimeChasing = 0;
        }
        else
        {
            currentTimeChasing += Time.deltaTime;
        }
    }
}
