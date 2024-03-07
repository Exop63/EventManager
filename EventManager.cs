public class EventManager
{
    // Dictionary to store UnityEvents by name
    private static Dictionary<string, object> eventDictionaryByName = new Dictionary<string, object>();

    // Invoke method for events with a single parameter
    public static void Invoke<T0>(T0 param)
    {
        Type eventType = typeof(T0);
        Invoke(eventType.Name, param);
    }

    // Invoke method for events with two parameters
    public static void Invoke<T0, T1>(T0 param, T1 client)
    {
        var key = typeof(T0).Name + typeof(T1).Name;
        if (eventDictionaryByName.ContainsKey(key))
        {
            var eventWithName = eventDictionaryByName[key] as UnityEvent<T0, T1>;
            eventWithName?.Invoke(param, client);
        }
        else
        {
            Debug.LogWarning($"No listeners for events of type {key}");
        }
    }

    // Invoke method for non-generic events
    public static void Invoke(string name)
    {
        if (eventDictionaryByName.ContainsKey(name))
        {
            UnityEvent eventWithName = eventDictionaryByName[name] as UnityEvent;
            eventWithName?.Invoke();
        }
        else
        {
            Debug.LogWarning($"No listeners for events of type {name}");
        }
    }

    // Invoke method for generic events with a single parameter
    public static void Invoke<T0>(string name, T0 value)
    {
        if (eventDictionaryByName.ContainsKey(name))
        {
            UnityEvent<T0> eventWithName = eventDictionaryByName[name] as UnityEvent<T0>;
            eventWithName?.Invoke(value);
        }
        else
        {
            Debug.LogWarning($"No listeners for events of type {name}");
        }
    }

    // Add listener to a non-generic event
    public static void AddListener(string name, UnityAction callback)
    {
        if (eventDictionaryByName.ContainsKey(name))
        {
            (eventDictionaryByName[name] as UnityEvent).AddListener(callback);
        }
        else
        {
            UnityEvent newEvent = new UnityEvent();
            newEvent.AddListener(callback);
            eventDictionaryByName.Add(name, newEvent);
        }
    }

    // Add listener to a generic event with a single parameter
    public static void AddListener<T0>(string name, UnityAction<T0> callback)
    {
        if (eventDictionaryByName.ContainsKey(name))
        {
            (eventDictionaryByName[name] as UnityEvent<T0>).AddListener(callback);
        }
        else
        {
            var newEvent = new UnityEvent<T0>();
            newEvent.AddListener(callback);
            eventDictionaryByName.Add(name, newEvent);
        }
    }

    // Add listener to a generic event using the type name as the event name
    public static void AddListener<T0>(UnityAction<T0> callback)
    {
        var name = typeof(T0).Name;
        if (eventDictionaryByName.ContainsKey(name))
        {
            (eventDictionaryByName[name] as UnityEvent<T0>).AddListener(callback);
        }
        else
        {
            var newEvent = new UnityEvent<T0>();
            newEvent.AddListener(callback);
            eventDictionaryByName.Add(name, newEvent);
        }
    }

    // Add listener to a generic event with two parameters
    public static void AddListener<T0, T1>(UnityAction<T0, T1> callback)
    {
        var key = typeof(T0).Name + typeof(T1).Name;
        if (eventDictionaryByName.ContainsKey(key))
        {
            (eventDictionaryByName[key] as UnityEvent<T0, T1>).AddListener(callback);
        }
        else
        {
            var newEvent = new UnityEvent<T0, T1>();
            newEvent.AddListener(callback);
            eventDictionaryByName.Add(key, newEvent);
        }
    }

    // Remove listener from a generic event with a single parameter
    public static void RemoveListener<T0>(UnityAction<T0> callback)
    {
        Type eventType = typeof(T0);
        if (eventDictionaryByName.ContainsKey(eventType.Name))
        {
            UnityEvent<T0> eventWithType = eventDictionaryByName[eventType.Name] as UnityEvent<T0>;
            eventWithType.RemoveListener(callback);

            // If no listeners remain, remove the event from the dictionary
            if (eventWithType.GetPersistentEventCount() == 0)
            {
                eventDictionaryByName.Remove(eventType.Name);
            }
        }
    }

    // Remove listener from a generic event with two parameters
    public static void RemoveListener<T0, T1>(UnityAction<T0, T1> callback)
    {
        var key = typeof(T0).Name + typeof(T1).Name;

        if (eventDictionaryByName.ContainsKey(key))
        {
            var eventWithType = eventDictionaryByName[key] as UnityEvent<T0, T1>;
            eventWithType.RemoveListener(callback);

            // If no listeners remain, remove the event from the dictionary
            if (eventWithType.GetPersistentEventCount() == 0)
            {
                eventDictionaryByName.Remove(key);
            }
        }
    }
}
