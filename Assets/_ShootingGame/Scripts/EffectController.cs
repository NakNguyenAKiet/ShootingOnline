using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace ShootingGame
{
    public class EffectController : ManualSingletonMono<EffectController>
    {
        public ParticleSystem _fireEffect;
        public VisualEffect _fireBallEffect;
        //public override void Awake()
        //{
        //    DontDestroyOnLoad(gameObject);
        //}
        public void PlayParticaleAtPos(ParticleSystem particleSystem, Vector3 Pos)
        {
            particleSystem.transform.position = Pos;
            particleSystem.Play();
        }
        public void PlayVFXAtPos(VisualEffect VFX, Vector3 Pos, string eventName)
        {
            VFX.transform.position = Pos;
            VFX.SendEvent(eventName);
        }
    }
}