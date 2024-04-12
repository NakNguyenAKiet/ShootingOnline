using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class PlayerController : MonoBehaviour
    {
        private static PlayerController _instance;
        public static PlayerController Instance => _instance;
        public LivingEntity LivingEntity;
        public AimingThirdPerson AimingThirdPerson;
        public StarterAssetsInputs StarterAssetsInputs;
        public InventoryController InventoryController;
        private void Awake()
        {
            if(_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        public void SetUpAwake()
        {

        }
        private void Reset()
        {
            LivingEntity = GetComponent<LivingEntity>();
            AimingThirdPerson = GetComponent<AimingThirdPerson>();
            StarterAssetsInputs = GetComponent<StarterAssetsInputs>();
        }
    }
}