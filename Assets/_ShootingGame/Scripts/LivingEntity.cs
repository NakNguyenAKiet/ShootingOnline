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
        }
    }
}
