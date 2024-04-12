using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public class ItemPickUpAble : MonoBehaviour
    {
        public ItemCode ItemCode;
        public void Picked()
        {
            GameObject.Destroy(gameObject);
        }
    }
}
