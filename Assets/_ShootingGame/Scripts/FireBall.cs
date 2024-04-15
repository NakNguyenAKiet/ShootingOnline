using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class FireBall : Projectile
    {
        [SerializeField] private float skillRangeRadius = 3;
        [SerializeField] private ItemCode _itemCode;

        protected async override void OnTriggerEnter(Collider other)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, skillRangeRadius);
            foreach (Collider collider in colliders)
            {
                Debug.Log(collider.name);
                if(collider.gameObject.TryGetComponent<LivingEntity>(out var target))
                {
                    await target.TakeDame(dame);
                }
            }
            gameObject.SetActive(false);
        }
    }
}