using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class PlayerController : AutoSingletonMono<PlayerController>
    {
        public LivingEntity LivingEntity;
        private void Reset()
        {
            LivingEntity = GetComponent<LivingEntity>();
        }
    }
}