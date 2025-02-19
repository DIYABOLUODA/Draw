using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DrawCardSystem
{
        /// <summary>
        /// 卡片类，里面装的是卡片自己的权重
        /// </summary>
    [Serializable]
    public class CardData 
    {
        [Tooltip("里面放的具体物品")]
        public Item item;
        [Tooltip("每一个物体的权重")]
        public float weight;

        public override bool Equals(object obj)
        {
            if (obj is CardData other)
            {
                return item == other.item && weight == other.weight;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (item, weight).GetHashCode();
        }

    }
}
