using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class PlaySoundFXOnCollision: MonoBehaviour
    {
        public bool PlayOnCreate = true;
        public SoundType soundType;
        public float Volumn = 1;
        private void Start()
        {
            if (PlayOnCreate)
            {
                PlayerController.Instance.SoundFXManager.PlaySoundAtPos(transform.position, soundType, 0.5f);
            }
        }
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