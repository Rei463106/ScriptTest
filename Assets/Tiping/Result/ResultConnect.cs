using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResultConnect : MonoBehaviour
{
    private Dictionary<RankScore, string> _rankDictionaly = new Dictionary<RankScore, string>();
    private int _correctCount;
    private Rank _rank;

    private void OnEnable()
    {
        foreach (var r in _rank.RankSettingList)
        {
            _rankDictionaly.TryAdd(r.RankScore, r.RankSet);
        }

        EventBus.Subscribe<AllConnectEvent>(this, AddScore);
        EventBus.Subscribe<FinishEvent>(this, HandOverScore);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    /// <summary>
    /// 一問正解するごとに加点
    /// </summary>
    /// <param name="a"></param>
    private void AddScore(AllConnectEvent a)
    {
        _correctCount++;
    }

    /// <summary>
    /// 最終的な点数とランクを渡す
    /// </summary>
    /// <param name="f"></param>
    private void HandOverScore(FinishEvent f)
    {
        StaticResult._finalCount = _correctCount;
        var fo = _rankDictionaly.FirstOrDefault(x => StaticResult._finalCount >= x.Key.MinRank && StaticResult._finalCount <= x.Key.MaxRank);
        StaticResult._finalRank = fo.Value;
    }
}
