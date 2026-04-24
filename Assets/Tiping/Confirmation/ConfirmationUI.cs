using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 正解時と不正解時のUIのイベントを書く
/// </summary>
public class ConfirmationUI : MonoBehaviour
{
    [Header("対応表")]
    [SerializeField] private TipeCorrespond _tipeCorrespond;
    [Header("ひらがな")]
    [SerializeField] private Text _kanaText;
    [Header("ローマ字")]
    [SerializeField] private Text _romaText;
    private Dictionary<string, string> _correspondWord = new Dictionary<string, string>();
    private int _kanaCount = 0;
    private int _romaCount = 0;
    private string _roma;//現在打ったところまで入っている…Inputの方に書いた方が良いかも

    private void OnEnable()
    {
        foreach (var i in _tipeCorrespond.CorrespondList)
        {
            _correspondWord.Add(i.Alphabet, i.Kana);
        }//ローマ字に対応するひらがな
    }

    /// <summary>
    /// 正解時
    /// </summary>
    private void CorrectText()
    {
        _romaCount++;

    }


}
