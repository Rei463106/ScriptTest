using UnityEngine;

public class InputConnect : MonoBehaviour
{
    private void Start()
    {
        InputChange._state = InputState.None;
    }

    private void Update()
    {
        var s = Input.inputString;
        if (!string.IsNullOrEmpty(s))
        {
            if (InputChange._state == InputState.None)
            {
                Debug.Log("押されました");
                var k = s[0];
                EventBus.Publish(new ConfirmationEvent(k));//確認
            }
        }
    }
}
