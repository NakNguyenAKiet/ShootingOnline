using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayVFXOnCollision : MonoBehaviour
{
    [SerializeField] private VisualEffect effect;
    private void OnTriggerEnter(Collider other)
    {
        if (effect != null)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            DestroyAfterSeconds destroyAfterSeconds;
            if (gameObject.TryGetComponent<DestroyAfterSeconds>(out destroyAfterSeconds))
            {
                destroyAfterSeconds.StartCoroutine(nameof(destroyAfterSeconds.DestroyDelay));
            }
            effect.Play();
        }
    }
}
