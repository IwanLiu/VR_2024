using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavmeshAgentFollower : MonoBehaviour
{
    NavMeshAgent navMesh;
    // Start is called before the first frame update
    NavMeshAgent agent;
    public Transform target;
    public Transform home;
    public Animator animator;
    public float minimumDistance = 10f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position,transform.position) < minimumDistance)
        {

            agent.SetDestination(target.position);

        }
        else
        {
            agent.SetDestination(home.position);
        }
        agent.SetDestination(target.position);
        animator.SetFloat("SPEED", agent.velocity.magnitude);
    }
}
