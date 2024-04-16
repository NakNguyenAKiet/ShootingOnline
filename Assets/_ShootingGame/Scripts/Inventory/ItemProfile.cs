using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public enum ItemCode
    {
        NoItem,
        BluePower,
        FireBall
    }
    public enum ItemType
    {
        NoType,
        Resource,
        Skill1,
        Skill2,
        Skill3,
    }
    [CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
    [Serializable]
    public class ItemProfile: ScriptableObject
    {
        public ItemCode ItemCode = ItemCode.NoItem;
        public ItemType ItemType = ItemType.NoType;
        public Sprite Image;
        public string ItemName;
        public string Description;
        public int DefaultMaxStack;
        public Transform Prefab;
    }
}
