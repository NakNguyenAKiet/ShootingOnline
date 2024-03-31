using UnityEngine;

namespace ShootingGame
{
    public class EnemyIdle : StateMachineBehaviour
    {
        float timer = 0;
        Transform player;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer = 0;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                animator.SetBool("isPatrolling", true);
            }

            float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);
            if (distanceToPlayer < 10)
            {
                animator.SetBool("isChasing", true);
            }
            else
            {
                animator.SetBool("isChasing", false);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Implement code that processes and affects root motion
        }

        // OnStateIK is called right after Animator.OnAnimatorIK()
        override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Implement code that sets up animation IK (inverse kinematics)
        }
    }
}
