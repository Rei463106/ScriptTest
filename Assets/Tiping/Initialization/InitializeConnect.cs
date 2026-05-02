using UnityEngine;

public class InitializeConnect : MonoBehaviour
{
    private InitializeRuntime _initializeR;
    private void OnEnable()
    {
        var list = SelectTipeList._tipeList;
        _initializeR = new InitializeRuntime(list);
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
