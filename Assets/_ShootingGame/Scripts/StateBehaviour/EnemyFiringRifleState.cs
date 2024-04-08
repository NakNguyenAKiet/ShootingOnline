using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ShootingGame
{
    public class EnemyFiringRifleState : StateMachineBehaviour
    {
        public Transform player;
        public float ShootingDelay = 1f;
        public float TimeShootingDelay = 1f;
        public float ChasingRange = 20f;
        public EnemyShootingController EnemyShootingController;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            ShootingDelay = 0;
            player = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
            EnemyShootingController = animator.GetComponent<EnemyShootingController>();
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<LookAtPlayer>().canRotate = true;

            float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);
            if (distanceToPlayer > ChasingRange)
            {
                animator.SetBool("isAttacking", false);
            }

            ShootingDelay += Time.deltaTime;
            if (ShootingDelay >= TimeShootingDelay) 
            {
                animator.SetTrigger("Shoot");
                ShootingDelay = 0;
                Vector3 _bulletDir = (player.position - EnemyShootingController.ProjectileSpawner.position).normalized;
                EnemyShootingController.BulletPool.SpawnObjectByDirection(EnemyShootingController.ProjectileSpawner, Quaternion.LookRotation(_bulletDir));
                EnemyShootingController.FireVFX.Play();

                Ray ray = new Ray(EnemyShootingController.ProjectileSpawner.position, _bulletDir);

                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 999f))
                {
                    EnemyShootingController.FlameVFX.transform.position = hitInfo.point;
                    EnemyShootingController.FlameVFX.Play();
                }
            }

        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<LookAtPlayer>().canRotate = false;
        }
    }
}
