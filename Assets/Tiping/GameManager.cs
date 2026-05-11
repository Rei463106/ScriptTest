using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("InitializeConnect")]
    [SerializeField] private InitializeConnect _initializeC;
    [Header("ConfirmationConnect")]
    [SerializeField] private ComfirmationConnect _comfirmationC;
    [Header("TimerConnect")]
    [SerializeField] private TimerConnect _timerConnect;
    [Header("InGameDirection")]
    [SerializeField] private InGameDirection _ingameDirection;

    private void Start()
    {
        var ct = this.GetCancellationTokenOnDestroy();
        WaitGameFinish(ct).Forget();
    }

    private async UniTask WaitGameFinish(CancellationToken token)
    {
        //初期化フェーズ
        await _ingameDirection.StartAnim(token);
        InputChange._state = InputState.None;
        TimerMove._timerEnum = TimerEnum.MoveTime;

        //入力フェーズ
        while (true)
        {
            var c = _initializeC.GoInitializeExecute();//問題が残ってるか調べる
            if (c > 0)
            {
                InputChange._state = InputState.None;
                TimerMove._timerEnum = TimerEnum.MoveTime;
            }
            else
                break;

            //問題
            await UniTask.WaitUntil(() => _comfirmationC.CurrentChar == '\0', cancellationToken: token);
            EventBus.Publish(new AllConnectEvent());
            await _ingameDirection.CorrectAnim(token);
        }
        //終了
        _ingameDirection.Finish();
    }
}
