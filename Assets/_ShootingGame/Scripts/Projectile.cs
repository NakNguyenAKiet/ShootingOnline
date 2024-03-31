using System.Collections;
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

        private void Start()
        {
            //Rigidbody.velocity = transform.forward * Speed;
        }
        public void ResetVelocity()
        {
            Rigidbody.velocity = transform.forward * Speed;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out LivingEntity target))
            {
                target.TakeDame(dame);
            }
            gameObject.SetActive(false);
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    if(other.TryGetComponent(out LivingEntity target))
        //    {
        //        target.TakeDame(dame);
        //    }
        //    gameObject.SetActive(false);
        //}
    }
}
