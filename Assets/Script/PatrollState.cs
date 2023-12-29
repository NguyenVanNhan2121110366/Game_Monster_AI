using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrollState : StateMachineBehaviour
{
    public Transform player;
    //float distanceChase = 8.0f;
    public List<Transform> point = new List<Transform>();
    float timer;
    public NavMeshAgent agent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0;
        this.agent = animator.GetComponent<NavMeshAgent>();
        GameObject go = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform child in go.transform)
        {
            point.Add(child);
        }
        this.agent.SetDestination(point[Random.Range(0, point.Count)].position);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            this.agent.SetDestination(point[Random.Range(0, point.Count)].position);
        }
        this.timer += Time.deltaTime;
        if (this.timer > 5)
        {
            animator.SetBool("isPatrolling", false);
        }

        //chase player
        float distance = Vector3.Distance(this.player.position, animator.transform.position);
        if (distance < 15)
        {
            animator.SetBool("IsChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
