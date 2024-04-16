using Cysharp.Threading.Tasks;
using deVoid.UIFramework;
using deVoid.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    [Serializable] public class UILobbyProperties: PanelProperties
    {

    }
    public class UILobby : APanelController<UILobbyProperties>
    {
        [SerializeField] private Slider _hPBar;
        [SerializeField] private Slider _energyBar;
        [SerializeField] private Transform _crossHair;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _dimButton;
        [SerializeField] private List<Image> _spellImages;
        protected async override void Awake()
        {
            base.Awake();
            await UniTask.WaitUntil(() => PlayerController.Instance != null);
            await UniTask.WaitUntil(() => UIFrameManager.Instance != null);
        }
        private async void Start()
        {
            await UniTask.WaitUntil(() => PlayerController.Instance != null);
            await UniTask.WaitUntil(() => PlayerController.Instance.LivingEntity != null);
            PlayerController.Instance.LivingEntity.SetHealthBar(_hPBar);
            _energyBar.maxValue = PlayerController.Instance.AimingThirdPerson.MaxEnergy;
        }
        protected override void AddListeners()
        {
            base.AddListeners();
            //_menuButton.onClick.AddListener(async () => await UIFrameManager.Instance.uIFrame.ShowPanel(ScreenIds.UIInventory));
            Signals.Get<TurnOnCrossHair>().AddListener(TurnOnCrossHair);
            Signals.Get<UpdateHP>().AddListener(UpdateHP);
            Signals.Get<UpdateEnergy>().AddListener(UpdateEnergy);
            Signals.Get<SetSpellEquipmentUI>().AddListener(UpdateSpellEquipmentUI);
        }
        private void UpdateSpellEquipmentUI(List<ItemInventory> itemInventories)
        {
            for(int i = 0; i < itemInventories.Count; i++)
            {
                if (itemInventories[i] == null || itemInventories[i].ItemProfile == null || itemInventories[i].ItemProfile.Image == null)
                {
                    _spellImages[i].gameObject.SetActive(false);
                }
                else
                {
                    _spellImages[i].sprite = itemInventories[i].ItemProfile.Image;
                    _spellImages[i].gameObject.SetActive(true);
                }
            }
        }
        private void TurnOnCrossHair(bool isOn)
        {
            _crossHair.gameObject.SetActive(isOn);
        }
        private void UpdateEnergy(float value)
        {
            _energyBar.value = value;
        }
        private void UpdateHP(float value)
        {
            _hPBar.value = value;
        }
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            //_menuButton.onClick.RemoveAllListeners();
            Signals.Get<TurnOnCrossHair>().RemoveListener(TurnOnCrossHair);
            Signals.Get<UpdateEnergy>().RemoveListener(UpdateEnergy);
            Signals.Get<UpdateHP>().RemoveListener(UpdateHP);
            Signals.Get<SetSpellEquipmentUI>().RemoveListener(UpdateSpellEquipmentUI);
        }
    }
}