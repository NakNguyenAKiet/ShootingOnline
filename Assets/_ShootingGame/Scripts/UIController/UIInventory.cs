using Cysharp.Threading.Tasks;
using deVoid.UIFramework;
using deVoid.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public class UIInventory : APanelController
    {
        public UIItemDetail UIItemDetail;
        public UIInventoryItem CurUIInventoryItem;
        public MouseFollower MouseFollower;
        public List<ItemInventory> EquipmentSpells = new();
        public List<UIInventoryItem> EquipmentSpellsUIs = new();

        [SerializeField] private UIInventoryItem inventoryItemPrefab;
        [SerializeField] private Transform _contentPanel;

        [SerializeField] private List<UIInventoryItem> inventoryItems = new() { };

        private bool HasInitial = false;
        protected override async void Awake()
        {
            base.Awake();
            await UniTask.WaitForSeconds(1);
            await InitialListItem(PlayerController.Instance.InventoryController.MaxSlot);
            HasInitial = true;
        }
        private void Start()
        {
            PlayerController.Instance.InventoryController.SetUIInventory(this);
            MouseFollower.Toggle(false);
            LoadItems();
        }
        private void OnEnable()
        {
            if(HasInitial)
            {
                LoadItems();
            }
        }
        public void UpdateEquipmentSpells(ItemInventory itemInventory)
        {
            switch (itemInventory.ItemProfile.ItemType)
            {
                case ItemType.Skill1:
                    EquipmentSpellsUIs[0].SetData(itemInventory);
                break;
                case ItemType.Skill2:
                    EquipmentSpellsUIs[1].SetData(itemInventory);
                    break;
                case ItemType.Skill3:
                    EquipmentSpellsUIs[2].SetData(itemInventory);
                    break;
            }
            for(int i = 0; i < EquipmentSpellsUIs.Count; i++)
            {

                EquipmentSpells[i] = EquipmentSpellsUIs[i].ItemInventory;
            }

            PlayerController.Instance.InventoryController.SetSpellEquipment(EquipmentSpells);
        }
        private Task InitialListItem(int quantity)
        {
            inventoryItems.Clear();
            for (int i = 0; i < quantity; i++) 
            {
                UIInventoryItem item = Instantiate(inventoryItemPrefab, _contentPanel);
                item.SetUIInventory(this);
                inventoryItems.Add(item);
            }
            return Task.CompletedTask;
        }
        public void LoadItems()
        {
            foreach (var item in inventoryItems)
            {
                item.ReSetData();
            }
            var listItemInventory = PlayerController.Instance.InventoryController.InventoryData.ItemInventories;
            for (int i = 0; i < listItemInventory.Count; i++)
            {
                inventoryItems[i].SetData(listItemInventory[i]);
            }

            var listSpellEquipment = PlayerController.Instance.InventoryController.InventoryData.EquipmentSpells;
            for (int i = 0; i < listSpellEquipment.Count; i++)
            {
                EquipmentSpells[i] = listSpellEquipment[i];
                EquipmentSpellsUIs[i].SetData(EquipmentSpells[i]);
            }

        }
    }
}