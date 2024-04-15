using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace ShootingGame
{
    public enum SoundType
    {
        none,
        Lazer,
        Electric,
        Fire,
        PickUpItem
    }
    public class SoundFXManager : ManualSingletonMono<SoundFXManager>
    {
        public AudioClip LandingAudioClip;
        public AudioClip[] FootstepAudioClips;
        [Range(0, 1)] public float FootstepAudioVolume = 0.5f;
        [SerializeField] private AudioClip _lazer;
        [SerializeField] private AudioClip _electric;
        [SerializeField] private AudioClip _fire;
        [SerializeField] private AudioClip _pickUpItem;
        //public override void Awake()
        //{
        //    base.Awake();
        //    DontDestroyOnLoad(this);
        //}
        public void PlaySoundAtPos(Vector3 position, SoundType soundType, float volumn)
        {
            switch (soundType)
            {
                case SoundType.Lazer:
                    AudioSource.PlayClipAtPoint(_lazer, position, volumn);
                    break;
                case SoundType.Electric:
                    AudioSource.PlayClipAtPoint(_electric, position, volumn);
                    break;
                case SoundType.Fire:
                    AudioSource.PlayClipAtPoint(_fire, position, volumn);
                    break;
                case SoundType.none:
                    break;
                case SoundType.PickUpItem:
                    AudioSource.PlayClipAtPoint(_pickUpItem, position, volumn);
                    break;
            }
        }
        public void PlayLazer()
        {
            AudioSource.PlayClipAtPoint(_lazer, transform.position, 0.5f);
        }
        private void OnLand(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                AudioSource.PlayClipAtPoint(LandingAudioClip, transform.position, 0.5f);
            }
        }
        public void Die(AnimationEvent animationEvent)
        {
            PlayerController.Instance.SoundFXManager.PlaySoundAtPos(transform.position, SoundType.Electric, 0.5f);
        }
        private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, FootstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.position, 0.5f);
                }
            }
        }
    }
}