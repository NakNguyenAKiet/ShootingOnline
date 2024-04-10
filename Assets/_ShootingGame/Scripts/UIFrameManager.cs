using deVoid.UIFramework;
using deVoid.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ShootingGame
{
    public class UIFrameManager : MonoBehaviour
    {
        private static UIFrameManager _instance;
        public static UIFrameManager Instance => _instance;
        [SerializeField] private UISettings defaultUISettings = null;

        public UIFrame uIFrame;

        public void Awake()
        {
            uIFrame = defaultUISettings.CreateUIInstance();
            var cameraData = Camera.main.GetUniversalAdditionalCameraData();
            cameraData.cameraStack.Add(uIFrame.GetComponentInChildren<Camera>());

            if((_instance != null))
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public bool HasScreenId(string id)
        {
            return Instance.uIFrame && uIFrame.IsScreenRegistered(id);
        }
    }
}