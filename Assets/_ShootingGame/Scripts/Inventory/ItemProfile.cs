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
        Spell_1
    }
    public enum ItemType
    {
        NoType,
        Resource,
        Skill
    }
    [CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
    public class ItemProfile: ScriptableObject
    {
        public ItemCode ItemCode = ItemCode.NoItem;
        public ItemType ItemType = ItemType.NoType;
        public Sprite Image;
        public string ItemName;
        public string Description;
        public int DefaultMaxStack;
    }
}
