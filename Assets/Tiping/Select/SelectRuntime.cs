using System.Collections.Generic;

public class SelectRuntime
{
    private Node _node;
    private Dictionary<Difficuty, NodeSetting> _selectDictionary = new Dictionary<Difficuty, NodeSetting>();
    private Difficuty _currentDifficulty;

    /// <summary>
    /// コンストラクター
    /// </summary>
    /// <param name="node"></param>
    public SelectRuntime(Node node)
    {
        _node = node;
        foreach (var d in _node.DifficultyInformation)
        {
            _selectDictionary.TryAdd(d.MyDifficulty, d.NodeSetting);
        }
        _currentDifficulty = Difficuty.Easy;
    }

    /// <summary>
    /// 右ボタンが押された時
    /// </summary>
    public void RightButton()
    {
        var c = _selectDictionary[_currentDifficulty].RightDifficulty;
        if (c == Difficuty.None)
            return;
        else
            _currentDifficulty = c;
    }

    /// <summary>
    /// 左ボタンが押された時
    /// </summary>
    public void LeftButton()
    {
        var c = _selectDictionary[_currentDifficulty].LeftDifficulty;
        if (c == Difficuty.None)
            return;
        else
            _currentDifficulty = c;
    }

    /// <summary>
    /// 決定ボタンが押された時
    /// </summary>
    public void DecisionButton()
    {
        var d = _selectDictionary[_currentDifficulty].TipeList;
        SelectTipeList._tipeList = d;//このリストを初期化の時に渡す(渡せるのか？渡し方は考える)
    }
}
