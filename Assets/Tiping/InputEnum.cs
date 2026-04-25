
/// <summary>
/// 入力を受け付けるかしないか
/// </summary>
public enum InputState
{
    None,
    Inputing
}

/// <summary>
/// 全体で管理する用
/// </summary>
public static class InputChange
{
    public static InputState _state;
}