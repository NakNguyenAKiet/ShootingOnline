using deVoid.UIFramework;
using deVoid.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ShootingGame.DefineSignals;

namespace ShootingGame
{
    [Serializable] public class UILobbyProperties: PanelProperties
    {

    }
    public class UILobby : APanelController<UILobbyProperties>
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private Slider _hPBar;
        [SerializeField] private Transform _crossHair;
        protected override void Awake()
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            _playerController.LivingEntity.SetHealthBar(_hPBar);

            Signals.Get<TurnOnCrossHair>().AddListener(TurnOnCrossHair);
        }
        private void TurnOnCrossHair(bool isOn)
        {
            _crossHair.gameObject.SetActive(isOn);
        }
        protected override void OnDestroy()
        {
            Signals.Get<TurnOnCrossHair>().RemoveListener(TurnOnCrossHair);
        }
    }
}