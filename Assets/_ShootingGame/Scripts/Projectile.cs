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
        [SerializeField] private EffectType _effectTypeOnHit;

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
        protected virtual async void OnTriggerEnter(Collider other)
        {
            if(_effectTypeOnHit != EffectType.none)
            {
                EffectManager.Instance.PlayEffectAtPos(_effectTypeOnHit, other.transform.position + new Vector3(0,1.5f,0));
            }
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
