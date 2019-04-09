using System.Collections.Generic;
using UnityEngine;

namespace Core.GameEvents
{
    [CreateAssetMenu(menuName = "Core/Game Event", fileName = "Game Event")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise ()
        {
            foreach (var listener in listeners)
            {
                listener.OnEventRaised();
            }
        }

        public void AddListener (GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener (GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
