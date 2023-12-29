using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class followPlayer : StateMachineBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform Dragon;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.agent = animator.GetComponent<NavMeshAgent>();
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.Dragon = GameObject.FindGameObjectWithTag("Dragon").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, this.player.position);
        if (distance <= 1.5)
        {
            animator.SetBool("AttackPlayer", true);
            animator.transform.LookAt(this.player);
        }
        if (distance < 10)
        {
            agent.SetDestination(this.player.position);
            animator.transform.LookAt(this.player);
        }

        if (distance > 10)
        {
            animator.SetBool("ChasingPlayer", false);

        }

        float distances = Vector3.Distance(this.Dragon.position, animator.transform.position);
        if(distances<5)
        {
            agent.SetDestination(this.Dragon.position);
            animator.transform.LookAt(this.Dragon);
        }
        if (distances <= 2)
        {
            animator.SetBool("AttackPlayer", true);
            animator.transform.LookAt(this.Dragon.position);
            
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
