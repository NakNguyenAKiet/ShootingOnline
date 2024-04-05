using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class VFXDestroyItSelf : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(DetroyDelay());
        }
        IEnumerator DetroyDelay()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}
