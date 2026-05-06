using System;

/// <summary>
/// ボタン用のイベント集
/// </summary>
public static class SelectButtonEvents
{
    public static Action _rightAction;
    public static Action _leftAction;
    public static Action _dicisionAction;

    public static void RightAction() => _rightAction.Invoke();
    public static void LeftAction() => _leftAction.Invoke();
    public static void DicisionAction() => _dicisionAction.Invoke();
}
