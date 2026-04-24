using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TipeList", menuName = "Tipe/TipeList")]
public class TipeList : ScriptableObject
{
    [Header("打ち込んでほしい言葉")]
    [SerializeField] private List<TipeName> _tipeList = new List<TipeName>();

    public List<TipeName> TList => _tipeList;
}

[Serializable]
public class TipeName
{
    [Header("打ち込んでほしい名前(ローマ字)")]
    [SerializeField]private string _name;
    [Header("打ち込んでほしい名前(ひらがな)")]
    [SerializeField] private string _kanaName;

    public string Name => _name;
    public string KanaName => _kanaName;
}
