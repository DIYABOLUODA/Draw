using System.Collections;
using System.Collections.Generic;
using DrawCardSystem;
using UnityEngine;

namespace Event 
{
    public class DrawCardEvent 
    {
        public int drawCount;
        public DrawCardEvent(int drawCount)
        {
            this.drawCount = drawCount;
        }
    }
}
