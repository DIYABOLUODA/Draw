using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public class JsonSerializer 
    {
        public string Serialize<T>(T obj, bool isNice)
        {
            return JsonUtility.ToJson(obj, isNice);
        }
        public T Deserialize<T>(string dataFromJson)
        {
            return JsonUtility.FromJson<T>(dataFromJson);
        }
    }
}
