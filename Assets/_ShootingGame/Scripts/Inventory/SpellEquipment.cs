using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingGame
{
    public enum SpellEquipmentType
    {
        Q,
        E,
        R
    }
    public class SpellEquipment : MonoBehaviour
    {
        [SerializeField] private SpellEquipmentType _equipmentType;
    }
}
