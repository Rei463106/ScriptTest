using UnityEngine;

public class InputConnect : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.Subscribe<InitializeEvent>(this, InitializeInput);
        EventBus.Subscribe<AllConnectEvent>(this, AllConnectInput);
        EventBus.Subscribe<FinishEvent>(this, FinishInput);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    private void Update()
    {
        var s = Input.inputString;
        if (!string.IsNullOrEmpty(s))
        {
            if (InputChange._state == InputState.None)
            {
                var k = s[0];
                EventBus.Publish(new ConfirmationEvent(k));//確認
            }
        }
    }

    private void InitializeInput(InitializeEvent i)
    {
        InputChange._state = InputState.Inputing;
    }

    private void AllConnectInput(AllConnectEvent a)
    {
        InputChange._state = InputState.Inputing;
    }

    private void FinishInput(FinishEvent f)
    {
        InputChange._state = InputState.Inputing;
    }
}
