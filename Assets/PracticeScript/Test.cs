using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.Subscribe<GameStartEvent>(this, Log);
        EventBus.Subscribe<GameStartEvent>(this, Log2);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    private void Start()
    {
        EventBus.Publish(new GameStartEvent());
    }

    private void Log(GameStartEvent e)
    {
        Debug.Log("a");
    }

    private void Log2(GameStartEvent e)
    {
        Debug.Log("b");
    }
}
