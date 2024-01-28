using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bounce.Utilities
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance { get; private set; }

        private readonly Dictionary<Type, IGameServices> _registeredServices = new Dictionary<Type, IGameServices>();

        private ServiceLocator()
        {

        }

        public static void Initiailze()
        {
            Instance = new ServiceLocator();
        }

        public T Get<T>() where T : IGameServices
        {
            Type type = typeof(T);
            if (_registeredServices.ContainsKey(type))
            {
                return (T)_registeredServices[type];
            }

            Debug.LogError($"{type} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }

        public void Register<T>(T service) where T : IGameServices
        {
            Type type = typeof(T);
            if (!_registeredServices.ContainsKey(type))
            {
                _registeredServices.Add(type, service);
                return;
            }

            Debug.LogError($"Attempted to register service of type {type} which is already registered with the {GetType().Name}.");
        }

        public void Unregister<T>() where T : IGameServices
        {
            Type type = typeof(T);
            if (_registeredServices.ContainsKey(type))
            {
                _registeredServices.Remove(type);
                return;
            }

            Debug.LogWarning($"Attempted to unregister service of type {type} which is not registered with the {GetType().Name}.");
        }
    }
}