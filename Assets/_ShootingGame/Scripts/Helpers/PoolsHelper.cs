using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

namespace ShootingGame
{
    public class PoolsHelper: MonoBehaviour
    {
        public List<Projectile> pooledObjects;
        public Projectile objectToPool;
        public int amountToPool;

        void Start()
        {
            pooledObjects = new List<Projectile>();
            Projectile tmp;
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.gameObject.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
        public Projectile GetPooledObject()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].gameObject.activeSelf)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
        public void SpawnObjectByDirection(Transform Dir, Quaternion targetRotation)
        {
            Projectile item = GetPooledObject();
            if (item != null)
            {
                item.transform.position = Dir.position;
                item.transform.rotation = targetRotation;
                item.ResetVelocity();
                item.gameObject.SetActive(true);
            }
        }
    }
}
