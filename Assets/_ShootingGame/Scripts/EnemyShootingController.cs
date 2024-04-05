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
        private void Reset()
        {
            Animator = GetComponent<Animator>();
        }
    }
}