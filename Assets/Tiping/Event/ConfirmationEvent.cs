/// <summary>
/// 確認用のイベント
/// </summary>
public struct ConfirmationEvent : IEvent
{
    public readonly char _inputChar;

    public ConfirmationEvent(char inputChar)
    {
        _inputChar = inputChar;
    }
}
