using UnityEngine;

public class InitializeConnect : MonoBehaviour
{
    [Header("TipeList")]
    [SerializeField] private TipeList _tipeList;

    private InitializeRuntime _initializeR;

    private void OnEnable()
    {
        _initializeR = new InitializeRuntime(_tipeList);
    }

    /// <summary>
    /// 名前の入った箱が残りいくつか返す
    /// </summary>
    /// <returns></returns>
    public int ReturnCount()
    {
        return _initializeR.tipeQueue.Count;
    }

    public void GoInitializeExecute()
    {
        _initializeR.InitializeExecute();
    }
}
