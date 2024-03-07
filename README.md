# EventManager

`EventManager` is a simple event management class in Unity that allows you to easily handle events with different types. It supports multiple overloads for invoking and adding listeners with various parameters.

## How to Use

### Basic Usage

1. **Invoke an Event:**

    ```csharp
    // Invoke an event without parameters
    EventManager.Invoke("eventName");

    // Invoke an event with a parameter
    EventManager.Invoke<int>("eventNameWithInt", 42);
    ```

2. **Add a Listener:**

    ```csharp
    // Add a listener without parameters
    EventManager.AddListener("eventName", YourCallbackFunction);

    // Add a listener with parameters
    EventManager.AddListener<int>("eventNameWithInt", YourCallbackFunctionWithInt);
    ```

3. **Remove a Listener:**

    ```csharp
    // Remove a listener without parameters
    EventManager.RemoveListener("eventName", YourCallbackFunction);

    // Remove a listener with parameters
    EventManager.RemoveListener<int>("eventNameWithInt", YourCallbackFunctionWithInt);
    ```

### Advanced Usage

1. **Invoke and Add Listeners with Multiple Parameters:**

    ```csharp
    // Invoke an event with multiple parameters
    EventManager.Invoke<int, string>("eventNameWithMultipleParams", 42, "Hello");

    // Add a listener with multiple parameters
    EventManager.AddListener<int, string>("eventNameWithMultipleParams", YourCallbackFunctionWithMultipleParams);
    ```

2. **Remove Listeners with Multiple Parameters:**

    ```csharp
    // Remove a listener with multiple parameters
    EventManager.RemoveListener<int, string>("eventNameWithMultipleParams", YourCallbackFunctionWithMultipleParams);
    ```

### Notes

- Events are uniquely identified by their names or a combination of parameter types.
- When removing a listener, if there are no remaining listeners for a specific event, the event is automatically removed from the internal dictionary.

Feel free to integrate and customize `EventManager` in your Unity project for efficient event handling.

## Example

Here is an example of a basic usage scenario:

```csharp
public class YourScript : MonoBehaviour
{
    private void Start()
    {
        // Add a listener for an event with an integer parameter
        EventManager.AddListener<int>("yourEventName", HandleIntEvent);
        // Add a listener for an event with generic parameter
        EventManager.AddListener<YourClass>(HandleYourClass);

        // Invoke the event with an integer parameter
        EventManager.Invoke<int>("yourEventName", 42);
        // Invoke the event with an generic parameter
        EventManager.AddListener<YourClass>(new YourClass());
   
    }

    private void HandleIntEvent(int value)
    {
        // Handle the event with the integer parameter
        Debug.Log($"Received event with value: {value}");
    }
    private void HandleYourClass(YourClass value)
    {
        // Handle the event with the integer parameter
        Debug.Log($"Received event with value: {value}");
    }
}
