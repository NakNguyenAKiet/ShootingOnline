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

        private void OnEnable()
        {
            ReSetData();
        }
        public void SetData(ItemInventory itemInventory)
        {
            image.gameObject.SetActive(true);
            image.sprite = itemInventory.ItemProfile.Image;
            this.detail.text = itemInventory.ItemProfile.Description;
            this.itemName.text = itemInventory.ItemProfile.name;
        }
        public void ReSetData()
        {
            image.gameObject.SetActive(false);
            this.detail.text = "";
            this.itemName.text = "";
        }
    }
}
