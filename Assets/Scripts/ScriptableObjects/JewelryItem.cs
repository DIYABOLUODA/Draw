using System.Collections;
using System.Collections.Generic;
using EnumType;
using UnityEngine;

namespace ScriptableObjects 
{
    [CreateAssetMenu(fileName = "JewelryType", menuName = "Item/Jewelry")]
    public class JewelryItem : Item
    {
        public JewelryType jewelryItem;
    }
}
