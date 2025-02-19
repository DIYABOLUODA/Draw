using System.Collections;
using System.Collections.Generic;
using EnumType;
using UnityEngine;

namespace ScriptableObjects 
{
    [CreateAssetMenu(fileName = "WeaponType", menuName = "Item/Weapon")]
    public class WeaponItem : Item
    {
        public WeaponType weaponType;
    }
}
