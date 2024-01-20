using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);
        

        if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

        if(isProvoked)
        {
            EngageTarget();
        }


        
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {
            Attack();
        }
        
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("isMoving");
        GetComponent<Animator>().SetBool("attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void Attack()
    {
        GetComponent<Animator>().SetTrigger("attack");
        Debug.Log("Attacking player");
    }


    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, chaseRange);
    }
}
