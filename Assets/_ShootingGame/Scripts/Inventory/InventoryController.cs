using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootingGame
{
    public class InventoryController : MonoBehaviour
    {
        public int MaxSlot;

        public List<ItemInventory> Items = new();
        [SerializeField] private ItemProfile[] profiles;
        [SerializeField] private UIInventory uIInventory;
        // Start is called before the first frame update
        private void Awake()
        {
            profiles = Resources.LoadAll<ItemProfile>("ItemProfiles");
        }
        public virtual bool AddItem(ItemCode itemCode, int addCount)
        {
            ItemInventory itemInventory = this.GetItemByCode(itemCode);

            int newCount = itemInventory.ItemCount + addCount;

            if (newCount > itemInventory.MaxStack) return false;

            itemInventory.ItemCount = newCount;

            return true;
        }
        public virtual ItemInventory GetItemByCode(ItemCode itemCode)
        {
            ItemInventory itemInventory = Items.Find((x) => x.ItemProfile.ItemCode == itemCode);

            if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);

            return itemInventory;
        }
        protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
        {
            foreach (ItemProfile profile in profiles)
            {
                if (profile.ItemCode != itemCode) continue;
                ItemInventory itemInventory = new ItemInventory
                {
                    ItemProfile = profile,
                    MaxStack = profile.DefaultMaxStack
                };
                this.Items.Add(itemInventory);
                return itemInventory;
            }
            return null;
        }
        public void SetUIInventory(UIInventory inventory)
        {
            uIInventory = inventory;
        }
    }
}