using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    [Serializable]
    public class ItemInventory
    {
        public ItemProfile ItemProfile;
        public int ItemCount = 0;
        public int MaxStack = 7;
    }
}