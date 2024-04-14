using deVoid.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootingGame
{
    public class InventoryController : MonoBehaviour
    {
        public int MaxSlot;

        public List<ItemInventory> ItemInventories = new();
        public List<ItemInventory> EquipmentSpells = new();
        [SerializeField] private ItemProfile[] profiles;
        [SerializeField] private UIInventory uIInventory;
        // Start is called before the first frame update
        private void Awake()
        {
            profiles = Resources.LoadAll<ItemProfile>("ItemProfiles");
        }
        public void SetSpellEquipment(List<ItemInventory> EquipmentSpells) 
        {
            this.EquipmentSpells = EquipmentSpells;
            Signals.Get<SetSpellEquipmentUI>().Dispatch(EquipmentSpells);
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
            ItemInventory itemInventory = ItemInventories.Find((x) => x.ItemProfile.ItemCode == itemCode);

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
                this.ItemInventories.Add(itemInventory);
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