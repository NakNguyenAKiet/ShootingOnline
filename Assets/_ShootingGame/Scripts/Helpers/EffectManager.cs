using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace ShootingGame
{
    public enum EffectType
    {
        none,
        RedFlame,
        pupleFlame,
        Fire,
    }
    public class EffectManager : MonoBehaviour
    {
        [SerializeField] private VisualEffect redFlame;
        [SerializeField] private VisualEffect pupleFlame;
        [SerializeField] private VisualEffect Fire;
        private static EffectManager _instance;
        public static EffectManager Instance => _instance;
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
            DontDestroyOnLoad(this);
        }
        public void PlayEffectAtPos(EffectType effectType, Vector3 pos)
        {
            switch (effectType)
            {
                case EffectType.none:
                    break;
                case EffectType.RedFlame:
                    redFlame.transform.position = pos;
                    redFlame.Play();
                    break;
                case EffectType.pupleFlame:
                    pupleFlame.transform.position = pos;
                    pupleFlame.Play();
                    break;
                case EffectType.Fire:
                    Fire.transform.position = pos;
                    Fire.SendEvent("hit");
                    break;

            }
        }
    }
}