using deVoid.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        [SerializeField] private ParticleSystem _particleOndead;
        [SerializeField] private GameObject _model;
        private void Reset()
        {
            animator = GetComponent<Animator>();
            healthBar.value = HP;
        }
        public async Task<Task> TakeDame(int dame)
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
            return Task.CompletedTask;
        }
        private void Die()
        {
            PlayerController.Instance.SoundFXManager.PlaySoundAtPos(transform.position, SoundType.Electric, 1f);
            animator.SetTrigger("isDying");
            transform.GetComponent<Collider>().enabled = false;
            
            if(_dropItem != null && _dropItem.ItemCode != ItemCode.NoItem)
            {
                Instantiate(_dropItem, transform);
                Instantiate(_particleOndead, transform);
            }

            Invoke(nameof(DestroyThis), 5);
        }
        private void DestroyThis() 
        {
            _model.SetActive(false);
        }
        public void SetHealthBar(Slider slider)
        {
            healthBar = slider;
        }
    }
}
