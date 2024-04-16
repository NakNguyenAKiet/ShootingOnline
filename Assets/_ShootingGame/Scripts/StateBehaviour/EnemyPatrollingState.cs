using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ShootingGame
{
    public class EnemyPatrollingState : StateMachineBehaviour
    {
        NavMeshAgent navMeshAgent;
        Transform player;
        Vector3 rootPosition;
        bool isSetRootPosition = false;
        float timer = 0;
        EnemyShootingController enemyShootingController;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            enemyShootingController = animator.GetComponent<EnemyShootingController>();
            if (!isSetRootPosition)
            {
                rootPosition = animator.transform.position;
                isSetRootPosition = true;
            }
            navMeshAgent = animator.GetComponent<NavMeshAgent>();
            navMeshAgent.speed = 1.5f;
            timer = 0;;
            SetRandomDestination();
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (navMeshAgent.remainingDistance <= 0.2f)
            {
                animator.SetBool("isPatrolling", false);
            }
            timer += Time.deltaTime;
            if (timer > 5)
            {
                animator.SetBool("isPatrolling", false);
            }

            float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);
            if (distanceToPlayer < enemyShootingController.ChasingRange)
            {
                animator.SetBool("isChasing", true);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            navMeshAgent.SetDestination(navMeshAgent.transform.position);
        }
        void SetRandomDestination()
        {
            Vector3 randomDirection = Random.insideUnitSphere * enemyShootingController.WanderRadius;
            randomDirection += rootPosition;
            NavMeshHit navHit;
            NavMesh.SamplePosition(randomDirection, out navHit, enemyShootingController.WanderRadius, NavMesh.AllAreas);
            navMeshAgent.SetDestination(navHit.position);
        }
    }
}
