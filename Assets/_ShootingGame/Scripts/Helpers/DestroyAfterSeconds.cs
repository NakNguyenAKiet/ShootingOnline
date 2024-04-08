using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class DestroyAfterSeconds : MonoBehaviour
    {
        [SerializeField] private float _timeToDestroy = 1;
        private void Start()
        {
            StartCoroutine(DestroyDelay());
        }
        public IEnumerator DestroyDelay()
        {
            yield return new WaitForSeconds(_timeToDestroy);
            Destroy(gameObject);
        }
    }
}
