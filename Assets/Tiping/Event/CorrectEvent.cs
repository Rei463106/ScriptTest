
/// <summary>
/// ³‰ğ‚ÌƒCƒxƒ“ƒg
/// </summary>
public struct CorrectEvent : IEvent
{
    public readonly char _correctChar;
    public CorrectEvent(char c)
    {
        _correctChar = c;
    }
}
