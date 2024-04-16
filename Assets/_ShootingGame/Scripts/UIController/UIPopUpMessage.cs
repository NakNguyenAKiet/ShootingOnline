using Cysharp.Threading.Tasks;
using deVoid.UIFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    [Serializable]
    public class UIPopUpMessageProperties:PanelProperties
    {
        public string Message;
    }
    public class UIPopUpMessage : APanelController<UIPopUpMessageProperties>
    {
        [SerializeField] private Button _okButton;
        [SerializeField] private TextMeshProUGUI _messageText;

        protected async override void OnPropertiesSet()
        {
            base.OnPropertiesSet();
            _messageText.text = Properties.Message;
            await UniTask.WaitForSeconds(3);
            Hide();
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Hide();
            }
        }
        protected override void AddListeners()
        {
            base.AddListeners();
            _okButton.onClick.AddListener(()=>Hide());
        }
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _okButton?.onClick.RemoveAllListeners();
        }
    }
}