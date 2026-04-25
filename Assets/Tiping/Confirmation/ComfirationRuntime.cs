
public class ComfirationRuntime
{
    private ComfirmationProcess _comfirmationP;
    private int _count;

    public ComfirationRuntime(TipeName tipeName)
    {
        _comfirmationP = new ComfirmationProcess(tipeName.Name);
        _count = _comfirmationP.Queue.Count;
    }

    /// <summary>
    /// 次に進めるかどうか
    /// </summary>
    /// <returns></returns>
    public int ReturnQueueCount()
    {
       return _count;
    }

    /// <summary>
    /// 現在の文字を返す
    /// </summary>
    /// <param name="ch"></param>
    /// <returns></returns>
    public char DequeueComfirmation()
    {
        if (_comfirmationP.Queue.Count > 0)
        {
            _count--;
            return _comfirmationP.Queue.Dequeue();
        }
        else
        {
            _count--;
            return '\0';
        }
    }
}
