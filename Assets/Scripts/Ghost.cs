using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
	public Transform player;
	private Vector3 initialPosition;
	private UnityEngine.AI.NavMeshAgent agent;
	private bool isMovingRandomly = false;

	public float moveSpeed = 5f;
    public float changeDirectionInterval = 3f; // Interval to change direction
    private float timer;
    private Vector3 randomDirection;

    void Start()
    {
        initialPosition = transform.position;
	    agent = GetComponent<UnityEngine.AI.NavMeshAgent>() ;
    }

    void Update()
    {
        if ( !isMovingRandomly )
        {
            agent.destination = player.position;
        }

    }
    public void ResetGhostPosition()
    {
        transform.position = initialPosition;
    }

    public void DisableNavMeshAgent()
    {
        if (agent != null)
        {
           agent.enabled = false;
        }
    }


}
