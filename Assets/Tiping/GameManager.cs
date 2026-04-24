using Cysharp.Threading.Tasks;
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
            //初期化実行
            _initializeC.GoInitializeExecute();
        }
        //ゲーム終了
    }
}
