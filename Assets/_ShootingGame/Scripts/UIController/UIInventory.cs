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
        [SerializeField] private UIInventoryItem inventoryItemPrefab;
        [SerializeField] private Transform _contentPanel;
        public UIItemDetail UIItemDetail;
        public UIInventoryItem CurUIInventoryItem;
        private bool HadInitial = false;

        private List<UIInventoryItem> inventoryItems = new();

        private async void Start()
        {
            PlayerController.Instance.InventoryController.SetUIInventory(this);
            await InitialListItem(PlayerController.Instance.InventoryController.MaxSlot);
            LoadItems();
        }
        private void OnEnable()
        {
            if(HadInitial)
            {
                LoadItems();
            }
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
            var listItemInventory = PlayerController.Instance.InventoryController.Items;
            for (int i = 0;i< listItemInventory.Count; i++)
            {
                inventoryItems[i].SetData(listItemInventory[i]);
            }
        }
    }
}