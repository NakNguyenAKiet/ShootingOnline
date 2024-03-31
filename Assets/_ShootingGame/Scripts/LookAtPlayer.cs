using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class LookAtPlayer : MonoBehaviour
    {
        Transform player;
        public bool canRotate;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (canRotate)
            {
                transform.LookAt(player);
            }
        }
    }
}
