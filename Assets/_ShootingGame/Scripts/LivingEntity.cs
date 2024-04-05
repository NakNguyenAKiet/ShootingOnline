using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public class LivingEntity : MonoBehaviour
    {
        [SerializeField] private int HP = 10;
        [SerializeField] private Animator animator;
        [SerializeField] private Slider healthBar;
        private void Reset()
        {
            animator = GetComponent<Animator>();
            healthBar.value = HP;
        }
        public void TakeDame(int dame)
        {
            HP -= dame;
            if (HP <= 0)
            {
                Die();
            }
            healthBar.value = HP;
        }
        private void Die()
        {
            animator.SetTrigger("isDying");
            transform.GetComponent<Collider>().enabled = false;

            Invoke(nameof(DestroyThis), 4);
        }
        private void DestroyThis() 
        {
            Destroy(gameObject);
        }
        public void SetHealthBar(Slider slider)
        {
            healthBar = slider;
        }
    }
}
