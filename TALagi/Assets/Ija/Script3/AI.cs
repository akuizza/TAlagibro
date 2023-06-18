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

    [Header("Transform")]
    public Transform[] patrolPoint;
    public NavMeshAgent agent;

    Vector3 destination;
    int index_patrolpoint;

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
}
