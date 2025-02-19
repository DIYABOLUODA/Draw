using System.Collections;
using System.Collections.Generic;
using EnumType;
using UnityEngine;

namespace ScriptableObjects 
{
    [CreateAssetMenu(fileName = "ArmorType", menuName = "Item/Armor")]
    public class ArmorItem : Item
    {
        public ArmorType armorType;
    }
}
