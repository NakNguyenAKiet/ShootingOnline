using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ShootingGame
{
    public class EnemyChasingState : StateMachineBehaviour
    {
        NavMeshAgent navMeshAgent;
        Transform player;
        EnemyShootingController EnemyShootingController;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            navMeshAgent = animator.GetComponent<NavMeshAgent>();
            EnemyShootingController = animator.GetComponent<EnemyShootingController>();
            navMeshAgent.speed = EnemyShootingController.Speed;
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            navMeshAgent.SetDestination(player.position);

            float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);
            if (distanceToPlayer > EnemyShootingController.ChasingRange + 5)
            {
                animator.SetBool("isChasing", false);
            }

            if (distanceToPlayer < EnemyShootingController.AttackRange)
            {
                animator.SetBool("isAttacking", true);
            }
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            navMeshAgent.SetDestination(navMeshAgent.transform.position);
        }
    }
}
