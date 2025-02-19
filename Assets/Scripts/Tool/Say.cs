using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool 
{
    public static class Say 
    {
        public static void say(string message , MessagesColor color)
        {
            Debug.Log($"<color={color}> {message} </color>");
        }
    }
}
