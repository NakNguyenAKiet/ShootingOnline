using deVoid.UIFramework;
using deVoid.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ShootingGame
{
    public class UIFrameManager : ManualSingletonMono<UIFrameManager>
    {
        [SerializeField] private UISettings defaultUISettings = null;

        public UIFrame uIFrame;

        public override void Awake()
        {
            base.Awake();
            uIFrame = defaultUISettings.CreateUIInstance();
            var cameraData = Camera.main.GetUniversalAdditionalCameraData();
            cameraData.cameraStack.Add(uIFrame.GetComponentInChildren<Camera>());
        }
        private void Start()
        {
            uIFrame.ShowPanel(ScreenIds.UILobby);
        }

        public bool HasScreenId(string id)
        {
            return Instance.uIFrame && uIFrame.IsScreenRegistered(id);
        }
    }
}