using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame {

    public class UIItemDetail : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI detail;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private ItemInventory itemInventory;

        private void OnEnable()
        {
            ReSetData();
        }
        public void SetData(ItemInventory itemInventory)
        {
            image.gameObject.SetActive(true);
            this.itemInventory = itemInventory;
            image.sprite = itemInventory.ItemProfile.Image;
            this.detail.text = $"{itemInventory.ItemProfile.Description} \n Type: {itemInventory.ItemProfile.ItemType}";
            this.itemName.text = itemInventory.ItemProfile.ItemName;
        }
        public void ReSetData()
        {
            image.gameObject.SetActive(false);
            this.detail.text = "";
            this.itemName.text = "";
        }
    }
}
