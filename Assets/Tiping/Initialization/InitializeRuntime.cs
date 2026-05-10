using System.Collections.Generic;

/// <summary>
/// ランタイム中の初期化処理
/// </summary>
public class InitializeRuntime
{
    private Queue<TipeName> _tipeQueue = new Queue<TipeName>();
    private int _count;

    public int Count => _count;

    public InitializeRuntime(TipeList tipeList)
    {
        foreach (var t in tipeList.TList)
        {
            _tipeQueue.Enqueue(t);
        }
        _count = _tipeQueue.Count;
    }

    /// <summary>
    /// 次の名前の入った箱を渡して実行
    /// </summary>
    /// <returns></returns>
    public void InitializeExecute()
    {
        if (_count > 0)
        {
            EventBus.Publish(new InitializeEvent(_tipeQueue.Dequeue()));
            _count--;
        }
        else
        {
            _count = -1;
            return;
        }
    }
}
