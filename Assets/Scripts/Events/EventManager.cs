using System.Collections.Generic;
using System;

namespace Bounce.EventSystem
{
    public class EventManager
    {
        public static EventManager Instance { get; private set; }

        private readonly Dictionary<int, Action> _gameEventsAndActions = new();

        private EventManager()
        {

        }

        public static void Initiailze()
        {
            Instance = new EventManager();
        }

        public void AddEvent(int eventID , Action action)
        {
            if (_gameEventsAndActions.ContainsKey(eventID))
            {
                _gameEventsAndActions[eventID] += action;
                return;
            }

            _gameEventsAndActions.Add(eventID, action);
        }

        public void RemoveEvent(int eventID, Action action)
        {
            if (_gameEventsAndActions.ContainsKey(eventID))
            {
                _gameEventsAndActions[eventID] -= action;
                return;
            }
        }
        public void InvokeEvent(int eventID)
        {
            if (_gameEventsAndActions.ContainsKey(eventID))
            {
                _gameEventsAndActions[eventID]?.Invoke();
                return;
            }

        }
    }
}

