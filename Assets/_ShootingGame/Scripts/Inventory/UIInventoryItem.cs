using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ShootingGame
{
    public class UIInventoryItem : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler, IDropHandler
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private GameObject _selectedImage;
        [SerializeField] private TextMeshProUGUI _itemCount;
        [SerializeField] private UIInventory _uIInventory;

        public ItemInventory ItemInventory;

        private void Awake()
        {
            ReSetData();
        }
        public void SetData(ItemInventory itemInventory)
        {
            if(itemInventory == null || itemInventory.ItemProfile==null || itemInventory.ItemProfile.ItemCode == ItemCode.NoItem) 
            {
                ReSetData();
                return;
            }
            _itemImage.gameObject.SetActive(true);
            this.ItemInventory = itemInventory;

            if(itemInventory.ItemProfile.Image != null)
            _itemImage.sprite = itemInventory.ItemProfile.Image;
            _itemCount.text = itemInventory.ItemCount.ToString();
        }
        public void SetUIInventory(UIInventory uIInventory)
        {
            _uIInventory = uIInventory;
        }
        public void ReSetData()
        {
            SelectedItem(false);
            _itemImage.gameObject.SetActive(false);
            _itemCount.text = "";
            ItemInventory = null;
        }
        public void SelectedItem(bool isOn)
        {
            _selectedImage.gameObject.SetActive(isOn);
        }
        public void OnDrag(PointerEventData eventData)
        {
            return;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (ItemInventory != null && ItemInventory.ItemProfile.ItemCode == ItemCode.NoItem) return;

            _uIInventory.MouseFollower.Toggle(false);

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                _uIInventory.UpdateEquipmentSpells(ItemInventory);
            }
            if (_uIInventory.CurUIInventoryItem != null)
            {
                _uIInventory.CurUIInventoryItem.SelectedItem(false);
            }
            _uIInventory.CurUIInventoryItem = this;
            SelectedItem(true);

            if(ItemInventory != null)
            {
                _uIInventory.UIItemDetail.SetData(ItemInventory);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (ItemInventory != null && ItemInventory.ItemProfile.ItemCode == ItemCode.NoItem) return;

            _uIInventory.MouseFollower.Toggle(true);
            _uIInventory.MouseFollower.SetData(ItemInventory);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.gameObject.TryGetComponent<UIInventoryItem>(out var item))
            {
                ItemInventory temp = ItemInventory;
                SetData(item.ItemInventory);
                item.SetData(temp);
            }
        }
    }
}
