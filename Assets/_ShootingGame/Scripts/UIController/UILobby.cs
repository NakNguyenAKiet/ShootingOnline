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
        protected async override void Awake()
        {
            base.Awake();
            Signals.Get<TurnOnCrossHair>().AddListener(TurnOnCrossHair);
            Signals.Get<UpdateHP>().AddListener(UpdateHP);
            Signals.Get<UpdateEnergy>().AddListener(UpdateEnergy);
        }
        private async void Start()
        {
            await UniTask.WaitUntil(() => PlayerController.Instance != null);
            await UniTask.WaitUntil(() => PlayerController.Instance.LivingEntity != null);
            PlayerController.Instance.LivingEntity.SetHealthBar(_hPBar);
            _energyBar.maxValue = PlayerController.Instance.AimingThirdPerson.MaxEnergy;
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
        protected override void OnDestroy()
        {
            Signals.Get<TurnOnCrossHair>().RemoveListener(TurnOnCrossHair);
            Signals.Get<UpdateEnergy>().RemoveListener(UpdateEnergy);
            Signals.Get<UpdateHP>().RemoveListener(UpdateHP);

        }
    }
}