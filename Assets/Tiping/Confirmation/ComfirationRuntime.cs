
public class ComfirationRuntime
{
    private ComfirmationProcess _comfirmationP;

    public ComfirationRuntime(TipeName tipeName)
    {
        _comfirmationP = new ComfirmationProcess(tipeName.Name);
    }

    /// <summary>
    /// 現在の文字数を返す
    /// </summary>
    /// <returns></returns>
    public int ReturnQueueCount()
    {
        return _comfirmationP.Queue.Count;
    }

    /// <summary>
    /// 初期化の際一文字目を返す
    /// </summary>
    /// <param name="ch"></param>
    /// <returns></returns>
    public char InitializeComfirmation()
    {
        return _comfirmationP.Queue.Dequeue();
    }
}
