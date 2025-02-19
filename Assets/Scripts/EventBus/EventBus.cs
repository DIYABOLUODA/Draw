using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventBus 
{
    public static class EventBus 
    {
        private static readonly Dictionary<Type, List<Delegate>> eventSubscribers = new();
        public static Action Subscribe<T>(Action<T> callback) where T : class
        {
            Type eventType = typeof(T);
            if (!eventSubscribers.ContainsKey(eventType))
            {
                eventSubscribers[eventType] = new List<Delegate>();
            }
            eventSubscribers[eventType].Add(callback);
            return () => Unsubscribe(callback);
        }
        private static void Unsubscribe<T>(Action<T> callback) where T : class
        {
            Type eventType = typeof(T);
            if(eventSubscribers.ContainsKey(eventType))
            {
                eventSubscribers[eventType].Remove(callback);
                if (eventSubscribers[eventType].Count == 0)
                {
                    eventSubscribers.Remove(eventType);
                }
            }
        }
        //发布事件
        public static void Publish<T>(T eventData) where T : class
        {
            Type eventType = typeof(T);
            if (eventSubscribers.ContainsKey(eventType))
            {
                foreach(Delegate subscriber in eventSubscribers[eventType])
                {
                    if(subscriber is Action<T> actonWithArgs)
                    {
                        actonWithArgs?.Invoke(eventData);
                    }else if(subscriber is Action actionWithoutArgs)
                    {
                        actionWithoutArgs?.Invoke();
                    }
                }
            }
        }
    }
}
