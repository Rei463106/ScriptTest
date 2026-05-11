using System.Collections.Generic;

/// <summary>
/// ランタイム中の初期化処理
/// </summary>
public class InitializeRuntime
{
    private Queue<TipeName> _tipeQueue = new Queue<TipeName>();

    public int TipeQueue => _tipeQueue.Count;

    public InitializeRuntime(TipeList tipeList)
    {
        foreach (var t in tipeList.TList)
        {
            _tipeQueue.Enqueue(t);
        }
    }

    /// <summary>
    /// 次の名前の入った箱を渡して実行
    /// </summary>
    /// <returns></returns>
    public void InitializeExecute()
    {
        EventBus.Publish(new InitializeEvent(_tipeQueue.Dequeue()));
    }
}
