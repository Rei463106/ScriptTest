using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TipeCorrespond", menuName = "Tipe/TipeCorrespond")]
public class TipeCorrespond : ScriptableObject
{
    [Header("対応表")]
    [SerializeField] private List<Correspond> _correspondList = new List<Correspond>();

    public List<Correspond> CorrespondList => _correspondList;
}

[Serializable]
public class Correspond
{
    [Header("ローマ字")]
    [SerializeField] private string _alphabet;
    [Header("対応する文字")]
    [SerializeField] private string _kana;

    public string Alphabet => _alphabet;
    public string Kana => _kana;
}
