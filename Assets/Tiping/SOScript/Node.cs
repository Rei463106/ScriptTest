using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node", menuName = "Node/Node")]
public class Node : ScriptableObject
{
    [Header("ノード設定")]
    [SerializeField] private Mydifficulty[] _difficultyInformation;
    public Mydifficulty[] DifficultyInformation => _difficultyInformation;
}

[Serializable]
public class Mydifficulty
{
    [Header("自分の難易度")]
    [SerializeField] private Difficuty _myDifficulty;
    [Header("NodeSetting")]
    [SerializeField] private NodeSetting _nodeSetting;
    public Difficuty MyDifficulty => _myDifficulty;
    public NodeSetting NodeSetting => _nodeSetting;
}

[Serializable]
public class NodeSetting
{
    [Header("右隣の難易度")]
    [SerializeField] private Difficuty _rightDifficulty;
    [Header("左隣の難易度")]
    [SerializeField] private Difficuty _leftDifficulty;
    [Header("対応するTipeList")]
    [SerializeField] private TipeList _tipeList;

    public Difficuty RightDifficulty => _rightDifficulty;
    public Difficuty LeftDifficulty => _leftDifficulty;
    public TipeList TipeList => _tipeList;
}


