using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace ShootingGame
{
    public class EnemyShootingController : MonoBehaviour
    {
        public Animator Animator;
        public Transform Projectile;
        public Transform ProjectileSpawner;
        public PoolsHelper BulletPool;
        public VisualEffect FireVFX;
        public VisualEffect FlameVFX;
        public float ChasingRange = 20;
        public float Speed = 3.5f;
        public float TimeShootingDelay = 1f;
        public float WanderRadius = 10f;
        public float AttackRange = 15f;

        private void Reset()
        {
            Animator = GetComponent<Animator>();
        }
    }
}