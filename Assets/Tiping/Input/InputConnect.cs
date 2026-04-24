using UnityEngine;

public class InputConnect : MonoBehaviour
{
    private void Update()
    {
        var s = Input.inputString[0];//何キーが押されたか入ってくる
        EventBus.Publish(new ConfirmationEvent(s));//確認
    }
}
