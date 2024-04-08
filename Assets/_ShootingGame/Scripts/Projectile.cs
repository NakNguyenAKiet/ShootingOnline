using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace ShootingGame
{
    public class Projectile : MonoBehaviour
    {
        public Rigidbody Rigidbody;
        public float Speed = 50f;
        public int dame = 5;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
        public void ResetVelocity()
        {
            Rigidbody.velocity = transform.forward * Speed;
        }
        public void SetDestination(Vector3 position, Vector3 Dir)
        {
            transform.position = position;
            transform.rotation = Quaternion.LookRotation(Dir);
            ResetVelocity();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out LivingEntity target))
            {
                target.TakeDame(dame);
            }
            gameObject.SetActive(false);
        }
    }
}
