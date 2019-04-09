using UnityEngine;
using UnityEngine.Events;

namespace Core.GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent  Event    = default;
        public UnityEvent Response = default;

        private void OnEnable ()
        {
            Event.AddListener(this);
        }

        private void OnDisable ()
        {
            Event.RemoveListener(this);
        }

        public void OnEventRaised ()
        {
            Response.Invoke();
        }
    }
}
