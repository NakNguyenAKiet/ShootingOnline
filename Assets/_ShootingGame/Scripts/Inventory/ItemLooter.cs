using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class ItemLooter : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private SphereCollider _sphereCollider;
        [SerializeField] private InventoryController _inventory;

        private void OnTriggerEnter(Collider other)
        {
            ItemPickUpAble item;
            if(other.TryGetComponent(out item))
            {
                if(_inventory.AddItem(item.ItemCode, 1))
                {
                    item.Picked();
                }
            }
        }
    }
}