using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("InitializeConnect")]
    [SerializeField] private InitializeConnect _initializeC;
    [Header("ConfirmationConnect")]
    [SerializeField] private ComfirmationConnect _comfirmationC;
    [Header("TimerConnect")]
    [SerializeField] private TimerConnect _timerC;
    [Header("InGameDirection")]
    [SerializeField] private InGameDirection _ingameDirection;

    private void OnEnable()
    {
        EventBus.Subscribe<FinishEvent>(this, FinishEvent);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    private void Start()
    {
        StartDirection().Forget();
    }

    private async UniTask WaitGameFinish()
    {
        while (_initializeC.ReturnCount() > 0)//箱が尽きるまでor時間切れ
        {
            Debug.Log(_timerC.CurrentTime());
            await UniTask.WaitUntil(() => _comfirmationC.ReturnCount() < 0);

            InputChange._state = InputState.Inputing;
            EventBus.Publish(new AllConnectEvent());//一問正解した時のイベント
            await _ingameDirection.CorrectAnim();//アニメーション
            //初期化実行
            _initializeC.GoInitializeExecute();
            InputChange._state = InputState.None;
        }
        //ゲーム終了     
        EventBus.Publish(new FinishEvent());
        await _ingameDirection.FinishAnim();
    }

    private async UniTask StartDirection()
    {
        InputChange._state = InputState.Inputing;
        TimerMove._timerEnum = TimerEnum.None;
        await _ingameDirection.StartAnim();
        _initializeC.GoInitializeExecute();//最初に初期化を実行
        InputChange._state = InputState.None;
        TimerMove._timerEnum = TimerEnum.MoveTime;
        WaitGameFinish().Forget();
    }

    private void FinishEvent(FinishEvent f)
    {
        InputChange._state = InputState.Inputing;
        TimerMove._timerEnum = TimerEnum.None;
    }
}
