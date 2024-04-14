using Cysharp.Threading.Tasks;
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
        private void Update()
        {
            //transform.LookAt(target);
        }
        public void ResetVelocity()
        {
            Rigidbody.velocity = transform.forward * Speed;
        }
        public void SetDestination(Vector3 position, Vector3 targetDir)
        {
            transform.position = position;
            transform.rotation = Quaternion.LookRotation(targetDir);
            ResetVelocity();
        }
        private async void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out LivingEntity target))
            {
                await target.TakeDame(dame);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
