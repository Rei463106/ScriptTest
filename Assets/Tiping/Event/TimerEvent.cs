
/// <summary>
/// 時間管理用イベント
/// </summary>
public struct TimerEvent : IEvent
{
    public readonly float _currentTime;
    public readonly float _limitTime;

    public TimerEvent(float currentTime, float limitTime)
    {
        _currentTime = currentTime;
        _limitTime = limitTime;
    }
}
