using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ShootingGame
{
    public class EnemyFiringRifleState : StateMachineBehaviour
    {
        public Transform player;
        private float ShootingDelay = 0;
        public EnemyShootingController EnemyShootingController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
            EnemyShootingController = animator.GetComponent<EnemyShootingController>();
            ShootingDelay = EnemyShootingController.TimeShootingDelay-0.8f;
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<LookAtPlayer>().canRotate = true;

            float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);
            if (distanceToPlayer > EnemyShootingController.AttackRange)
            {
                animator.SetBool("isAttacking", false);
            }

            ShootingDelay += Time.deltaTime;
            if (ShootingDelay >= EnemyShootingController.TimeShootingDelay) 
            {
                PlayerController.Instance.SoundFXManager.PlaySoundAtPos(animator.transform.position, SoundType.Lazer, 0.5f);
                animator.SetTrigger("Shoot");
                ShootingDelay = 0;
                Vector3 _bulletDir = (player.position - EnemyShootingController.ProjectileSpawner.position).normalized;
                EnemyShootingController.BulletPool.SpawnObjectByDirection(EnemyShootingController.ProjectileSpawner, Quaternion.LookRotation(_bulletDir));
                EnemyShootingController.FireVFX.Play();
            }

        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<LookAtPlayer>().canRotate = false;
        }
    }
}
