using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class PlaySoundFXOnCollision: MonoBehaviour
    {
        public SoundType soundType;
        public float Volumn = 1;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (soundType != SoundType.none)
            {
                PlayerController.Instance.SoundFXManager.PlaySoundAtPos(transform.position, soundType, Volumn);
            }
        }
    }
}