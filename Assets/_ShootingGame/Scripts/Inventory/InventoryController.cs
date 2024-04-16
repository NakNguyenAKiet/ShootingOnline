using Cysharp.Threading.Tasks;
using deVoid.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootingGame
{
    [Serializable]
    public class InventoryData
    {
        public List<ItemInventory> ItemInventories = new();
        public List<ItemInventory> EquipmentSpells = new();
    }
    public class InventoryController : MonoBehaviour
    {
        public int MaxSlot;

        public InventoryData InventoryData;
        [SerializeField] private ItemProfile[] profiles;
        [SerializeField] private UIInventory uIInventory;
        // Start is called before the first frame update
        private void Awake()
        {
            profiles = Resources.LoadAll<ItemProfile>("ItemProfiles");
        }
        private async void Start()
        {
            InventoryData inventoryData = PlayerController.Instance.JsonSavingController.GetInventoryData();
            if(inventoryData != null)
            {
                InventoryData = inventoryData;
                await UniTask.WaitForSeconds(0.5f);
                Signals.Get<SetSpellEquipmentUI>().Dispatch(InventoryData.EquipmentSpells);
            }
        }
        public void SetSpellEquipment(List<ItemInventory> EquipmentSpells) 
        {
            this.InventoryData.EquipmentSpells = EquipmentSpells;
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
            ItemInventory itemInventory = InventoryData.ItemInventories.Find((x) => x.ItemProfile.ItemCode == itemCode);

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
                this.InventoryData.ItemInventories.Add(itemInventory);
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