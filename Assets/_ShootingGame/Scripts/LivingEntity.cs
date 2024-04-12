using deVoid.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public enum LivingEntityType
    {
        player,
        enemy
    }
    public class LivingEntity : MonoBehaviour
    {
        [SerializeField] private int HP = 10;
        [SerializeField] private Animator animator;
        [SerializeField] private Slider healthBar;
        [SerializeField] private LivingEntityType _livingEntityType;
        [SerializeField] private ItemPickUpAble _dropItem;
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
            if(_livingEntityType == LivingEntityType.player)
            {
                Signals.Get<UpdateHP>().Dispatch(HP);
            }
            else
            {
                healthBar.value = HP;
            }
        }
        private void Die()
        {
            animator.SetTrigger("isDying");
            transform.GetComponent<Collider>().enabled = false;
            
            if(_dropItem != null && _dropItem.ItemCode != ItemCode.NoItem)
            {
                Instantiate(_dropItem, transform);
            }

            Invoke(nameof(DestroyThis), 5);
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
