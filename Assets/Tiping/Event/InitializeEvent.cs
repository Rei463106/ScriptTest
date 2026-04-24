public readonly struct InitializeEvent : IEvent
{
    public readonly TipeName _tipeName;

    public InitializeEvent(TipeName tipeName)
    {
        _tipeName = tipeName;
    }
}
