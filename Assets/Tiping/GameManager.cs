using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("InitializeConnect")]
    [SerializeField] private InitializeConnect _initializeC;
    [Header("ConfirmationConnect")]
    [SerializeField] private ComfirmationConnect _comfirmationC;

    private void Start()
    {
        _initializeC.GoInitializeExecute();//最初に初期化を実行
        WaitGameFinish().Forget();
    }

    private async UniTask WaitGameFinish()
    {
        while (_initializeC.ReturnCount() > 0)//箱が尽きるまで…
        {
            await UniTask.WaitUntil(() => _comfirmationC.ReturnCount() < 0);
            InputChange._state = InputState.Inputing;
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            //初期化実行
            _initializeC.GoInitializeExecute();
            InputChange._state = InputState.None;
        }
        //ゲーム終了
    }
}
