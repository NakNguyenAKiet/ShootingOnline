using System;
using System.IO;
using UnityEngine;

namespace ShootingGame
{
    public class JsonSavingController
    {
        private string _persistentpathInventory = "";
        public void SetPath()
        {
            _persistentpathInventory = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "InventoryData.json";
        }
        public void SaveData()
        {
            string path = _persistentpathInventory;
            Debug.Log("Save InventoryData at: " + path);
            string json = JsonUtility.ToJson(PlayerController.Instance.InventoryController.InventoryData);

            using StreamWriter writer = new StreamWriter(path);
            writer.Write(json);
            writer.Close();
        }
        public InventoryData GetListItemInventoryData()
        {
            InventoryData InventoryData = null;
            try
            {
                using StreamReader reader = new StreamReader(_persistentpathInventory);
                string json = reader.ReadToEnd();
                reader.Close();
                InventoryData = JsonUtility.FromJson<InventoryData>(json);
            }
            catch(Exception ex)
            {
                Debug.Log("Path null: " + ex.Message);
            }
            return InventoryData;
        }
    }
}