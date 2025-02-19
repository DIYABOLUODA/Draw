using UnityEngine;
using EnumType;
using System;

namespace ScriptableObjects
{
[Serializable]
    
    public abstract class Item : ScriptableObject
    {
        public string itemName;
        public Sprite itemSprite;
        public MainItemType mainItemType;
        public Quality quality;
    }
}
