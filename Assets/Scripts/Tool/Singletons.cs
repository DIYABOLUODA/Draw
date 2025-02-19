using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool 
{
    public class Singletons<T> : MonoBehaviour where T : Component
    {
        protected static T instance;
        public static bool HasInstance => instance != null;
        public static T TryGetInstance() => HasInstance ? instance : null;
        public static T Instance
        {
            get
            {
                Debug.Log($"{typeof(T).Name} - Current instance: {instance}");
                if (instance == null)
                {
                    Debug.Log($"{typeof(T).Name} - Found in scene: {instance}");
                    instance = FindAnyObjectByType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject(typeof(T).Name + "Auto - Generated").AddComponent<T>();
                        Debug.Log($"{typeof(T).Name} - Created new AUTO instance: {instance}");
                    }
                }
                return instance;
            }
        }
        protected virtual void Awake()
        {
            InitializeSingleton();
        }
        protected virtual void InitializeSingleton()
        {
            if(!Application.isPlaying) return;
             instance = this as T;
        }
    }
}
