using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace OrdersManager.Core.Domain
{
    /// <summary>
    /// Domain events responsible for registering and raising events
    /// </summary>
    public static class DomainEvents
    {
        /// <summary>
        /// The actions
        /// </summary>
        [ThreadStatic]
        private static List<Delegate> actions;

        /// <summary>
        /// The container
        /// </summary>
        private static IServiceProvider Container;

        /// <summary>
        /// Initializes the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Init(IServiceProvider container)
        {
            Container = container;
        }

        //Registers a callback for the given domain event, used for testing only
        /// <summary>
        /// Registers the specified callback.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callback">The callback.</param>
        public static void Register<T>(Action<T> callback) where T : DomainEvent
        {
            if (actions == null)
                actions = new List<Delegate>();

            actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        /// <summary>
        /// Clears the callbacks.
        /// </summary>
        public static void ClearCallbacks()
        {
            actions = null;
        }

        //Raises the given domain event
        /// <summary>
        /// Raises the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        public static void Raise<T>(T args) where T : DomainEvent
        {
            if (Container != null)
                foreach (var handler in Container.GetServices<IHandles<T>>())
                    handler.Handle(args);

            if (actions != null)
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(args);
        }
    }
}
