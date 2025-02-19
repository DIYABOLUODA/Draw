using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Event 
{
    public class ReturnDrawUIEvent 
    {
        public List<GameObject> gameObjects;
        public ReturnDrawUIEvent(List<GameObject> gameObjects)
        {
            this.gameObjects = gameObjects;
        }
    }
}
