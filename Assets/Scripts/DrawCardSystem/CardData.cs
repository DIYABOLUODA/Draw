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
        /// ��Ƭ�࣬����װ���ǿ�Ƭ�Լ���Ȩ��
        /// </summary>
    [Serializable]
    public class CardData 
    {
        [Tooltip("����ŵľ�����Ʒ")]
        public Item item;
        [Tooltip("ÿһ�������Ȩ��")]
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
