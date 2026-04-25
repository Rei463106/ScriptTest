using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUI : MonoBehaviour
{
    [Header("対応表")]
    [SerializeField] private TipeCorrespond _tipeCorrespond;
    [Header("ひらがな")]
    [SerializeField] private Text _kanaText;
    [Header("ローマ字")]
    [SerializeField] private Text _romaText;
    private Dictionary<string, string> _correspondWord = new Dictionary<string, string>();
    private int _kanaCount = 0;
    private string _roma = "";
    private string _kana;//現在打ったところまで入っている

    private void OnEnable()
    {
        foreach (var i in _tipeCorrespond.CorrespondList)
        {
            _correspondWord.TryAdd(i.Alphabet, i.Kana);
        }//ローマ字に対応するひらがな

        EventBus.Subscribe<InitializeEvent>(this, InitializeUI);
        EventBus.Subscribe<CorrectEvent>(this, CorrectText);
        EventBus.Subscribe<InCorrectEvent>(this, InCorrectText);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    /// <summary>
    /// 正解時
    /// </summary>
    private void CorrectText(CorrectEvent c)
    {
        _roma += c._correctChar;
        _romaText.text += c._correctChar;//今まで打ったとこまで入る
        if (_correspondWord.TryGetValue(_roma, out var w))
        {
            Debug.Log(w);
            _kanaCount++;
            //入力済みだけ色が変わる？
            string colored = $"<color=yellow>{_kana.Substring(0, _kanaCount)}</color>" + _kana.Substring(_kanaCount);
            _kanaText.text = colored;
            _roma = "";
        }//辞書に対応するひらがながあったら変更
    }

    /// <summary>
    /// 不正解時
    /// </summary>
    private void InCorrectText(InCorrectEvent i)
    {
        InCorrectTask().Forget();
    }

    private async UniTask InCorrectTask()
    {
        _romaText.color = Color.red;
        _kanaText.color = Color.red;
        InputChange._state = InputState.Inputing;
        //入力できなくする
        await UniTask.Delay(TimeSpan.FromSeconds(5f));
        //入力できるようにする
        InputChange._state = InputState.None;
        _romaText.color = Color.white;
        _kanaText.color = Color.white;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void InitializeUI(InitializeEvent i)
    {
        _kanaCount = 0;
        _kana = i._tipeName.KanaName;//初期化時にひらがな全体を代入
    }
}
