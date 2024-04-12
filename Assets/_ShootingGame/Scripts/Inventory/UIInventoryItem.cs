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
    public class UIInventoryItem : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private GameObject _selectedImage;
        [SerializeField] private TextMeshProUGUI _itemCount;
        [SerializeField] private UIInventory UIInventory;
        [SerializeField] private ItemInventory itemInventory;

        public void SetData(ItemInventory itemInventory)
        {
            _itemImage.gameObject.SetActive(true);
            this.itemInventory = itemInventory;
            _itemImage.sprite = itemInventory.ItemProfile.Image;
            _itemCount.text = itemInventory.ItemCount.ToString();
        }
        public void SetUIInventory(UIInventory uIInventory)
        {
            UIInventory = uIInventory;
        }
        public void ReSetData()
        {
            SelectedItem(false);
            _itemImage.sprite=null;
            _itemImage.gameObject.SetActive(false);
            _itemCount.text = "";
            itemInventory = null;
        }
        public void SelectedItem(bool isOn)
        {
            _selectedImage.gameObject.SetActive(isOn);
        }
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = 0;
            _itemImage.transform.position = MousePos;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
        }

        public void OnPointerClick(PointerEventData eventData)
        {

            if(UIInventory.CurUIInventoryItem != null)
            {
                UIInventory.CurUIInventoryItem.SelectedItem(false);
            }
            UIInventory.CurUIInventoryItem = this;
            SelectedItem(true);

            if(itemInventory != null)
            {
                UIInventory.UIItemDetail.SetData(itemInventory);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
        }
    }
}
