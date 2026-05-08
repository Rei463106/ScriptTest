using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rank", menuName = "Rank/Rank")]
public class Rank : ScriptableObject
{
    [Header("ランク集")]
    [SerializeField] private List<RankSetting> _rankSettingList = new List<RankSetting>();

    public List<RankSetting> RankSettingList => _rankSettingList;
}

[Serializable]
public class RankSetting
{
    [Header("ランク")]
    [SerializeField] private string _rank;
    [Header("RankScore")]
    [SerializeField] private RankScore _rankScore;

    public string RankSet => _rank;
    public RankScore RankScore => _rankScore;
}

[Serializable]
public class RankScore
{
    [Header("ランク最大値")]
    [SerializeField] private int _maxRank;
    [Header("ランク最小値")]
    [SerializeField] private int _minRank;

    public int MaxRank => _maxRank;
    public int MinRank => _minRank;
}
