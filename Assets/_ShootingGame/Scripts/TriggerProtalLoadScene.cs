using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingGame
{
    public enum SceneId
    {
        Splash,
        Moden,
        ModenLight
    }
    public class TriggerProtalLoadScene : MonoBehaviour
    {
        public SceneId SceneId;
        private async void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController.Instance.JsonSavingController.SaveData();
                await UniTask.WaitForSeconds(0.5f);
                await SceneManager.LoadSceneAsync((int)SceneId);
            }
        }
    }
}