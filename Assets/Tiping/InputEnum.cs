
/// <summary>
/// 入力を受け付けるかしないか
/// </summary>
public enum InputState
{
    None,
    Inputing
}

public static class InputChange
{
    public static InputState _state;
}