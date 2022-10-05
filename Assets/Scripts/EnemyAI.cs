using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float leashRange = 5f;

    NavMeshAgent navMeshAgent;
    float targetDistance = Mathf.Infinity; // Start is called before the first frame update

    bool targetAcquired = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        LeashEnemy();
        PrintChasingStatus();

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, leashRange);
    }

    private void LeashEnemy()
    {
        targetAcquired = false;
        targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance <= leashRange)
        {

            SetTarget();
        }
    }

    private void SetTarget()
    {
        targetAcquired = true;

        navMeshAgent.destination = target.position;

    }

    private void PrintChasingStatus()
    {
        string debugMessage = "";
        switch (targetAcquired)
        {
            case true:
                debugMessage = "chasing";
                break;
            case false:
                debugMessage = "no target - idle";
                break;
            default:
                debugMessage = "";
                break;
        }
        Debug.Log(debugMessage);

    }
}
