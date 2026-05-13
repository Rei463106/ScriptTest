using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputUI : MonoBehaviour
{
    [Header("対応表")]
    [SerializeField] private TipeCorrespond _tipeCorrespond;
    [Header("ひらがな")]
    [SerializeField] private TextMeshProUGUI _kanaText;
    [Header("ローマ字")]
    [SerializeField] private TextMeshProUGUI _romaText;
    private Dictionary<string, int> _correspondNumber = new Dictionary<string, int>();
    private int _kanaCount = 0;
    private string _roma = "";
    private string _kana;//現在打ったところまで入っている

    private void OnEnable()
    {
        foreach (var i in _tipeCorrespond.CorrespondList)
        {
            _correspondNumber.TryAdd(i.Alphabet, i.AlphabetNumber);
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
        if (_correspondNumber.TryGetValue(_roma, out var w))
        {
            _kanaCount += w;//正解したところまで黄色文字にする
            string colored = $"<color=yellow>{_kana.Substring(0, _kanaCount)}</color>" + _kana.Substring(_kanaCount);
            _kanaText.text = colored;
            _roma = "";
        }//正解したら合ってるところまで文字色を変える
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
        InputChange._state = InputState.Inputing;
        //入力できなくする
        await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
        //入力できるようにする
        InputChange._state = InputState.None;
        _romaText.color = Color.black;
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
