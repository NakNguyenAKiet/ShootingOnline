using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class PlayerController : ManualSingletonMono<PlayerController>
    {
        public LivingEntity LivingEntity;
        public AimingThirdPerson AimingThirdPerson;
        public void SetUpAwake()
        {

        }
        private void Reset()
        {
            LivingEntity = GetComponent<LivingEntity>();
            AimingThirdPerson = GetComponent<AimingThirdPerson>();
        }
    }
}