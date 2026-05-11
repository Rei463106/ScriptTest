using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class InputConnect : MonoBehaviour
{
    [Header("SESource")]
    [SerializeField] private AudioSource _seSource;
    [Header("PushSound")]
    [SerializeField] private AudioClip _seClip;

    private void OnEnable()
    {
        EventBus.Subscribe<InitializeEvent>(this, InitializeInput);
        EventBus.Subscribe<AllConnectEvent>(this, AllConnectInput);
        EventBus.Subscribe<FinishEvent>(this, FinishInput);
        var ct = this.GetCancellationTokenOnDestroy();
        InputString(ct).Forget();
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    /// <summary>
    /// 入力を受け取る
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    private async UniTask InputString(CancellationToken token)
    {
        while (true)
        {
            await UniTask.WaitUntil(() => Input.anyKeyDown, cancellationToken: token);
            string s = Input.inputString;
            if (InputChange._state == InputState.None)
            {
                _seSource.PlayOneShot(_seClip);
                var k = s[0];
                EventBus.Publish(new ConfirmationEvent(k));//確認
            }
            else
                continue;
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
