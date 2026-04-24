using UnityEngine;

public class InputConnect : MonoBehaviour
{
    private void Update()
    {
        var s = Input.inputString;
        if (!string.IsNullOrEmpty(s))
        {
            var k = s[0];
            EventBus.Publish(new ConfirmationEvent(k));//確認
        }     
    }
}
