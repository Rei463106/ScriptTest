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
        _initializeC.GoInitializeExecute();
        await _ingameDirection.StartAnim(token);
        InputChange._state = InputState.None;
        TimerMove._timerEnum = TimerEnum.MoveTime;

        //入力フェーズ
        while (true)
        {
            //箱の数が0になったら終わり
            if (_initializeC.ReturnCount() < 0)
                break;

            //問題
            await UniTask.WaitUntil(() => _comfirmationC.ReturnCount() < 0, cancellationToken: token);
            EventBus.Publish(new AllConnectEvent());
            await _ingameDirection.CorrectAnim(token);

            //ループ
            _initializeC.GoInitializeExecute();
            InputChange._state = InputState.None;
            TimerMove._timerEnum = TimerEnum.MoveTime;
        }

        //終了
        _ingameDirection.Finish();
    }
}
