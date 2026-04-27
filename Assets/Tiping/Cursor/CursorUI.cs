using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カーソルの点滅・移動などを書く
/// </summary>
public class CursorUI : MonoBehaviour
{
    [Header("カーソル")]
    [SerializeField] private Image _cursor;
    [Header("カーソルの位置")]
    [SerializeField] private RectTransform _cursorTransform;
    [Header("カーソル動くText")]
    [SerializeField] private TextMeshProUGUI _romaText;

    private int i = 0;

    private void OnEnable()
    {
        EventBus.Subscribe<InitializeEvent>(this, InitializeCursor);
        EventBus.Subscribe<CorrectEvent>(this, CorrectCursor);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    private void Start()
    {
        BlinkCursor().Forget();
    }

    private void Update()
    {
        var textInfo = _romaText.textInfo;

        if (textInfo.characterCount == 0)
        {
            _cursorTransform.anchoredPosition = Vector2.zero;
            return;
        }

        int lastIndex = textInfo.characterCount - 1;

        if (lastIndex < 0 || lastIndex >= textInfo.characterInfo.Length)
            return;

        var charInfo = textInfo.characterInfo[lastIndex];
    }


    private async UniTask BlinkCursor()
    {
        while (i == 0)
        {
            _cursor.enabled = true;
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            _cursor.enabled = false;
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="i"></param>
    private void InitializeCursor(InitializeEvent i)
    {
        //CursorMove();
    }

    /// <summary>
    /// 正解時にカーソルを動かす
    /// </summary>
    /// <param name="c"></param>
    private void CorrectCursor(CorrectEvent c)
    {
        //CursorMove();
    }

    private void CursorMove()
    {
        _romaText.ForceMeshUpdate();

        var textInfo = _romaText.textInfo;

        if (textInfo.characterCount == 0)
        {
            _cursorTransform.anchoredPosition = Vector2.zero;
            return;
        }

        var charInfo = textInfo.characterInfo[textInfo.characterCount - 1];

        _cursorTransform.anchoredPosition = charInfo.topRight;
    }
}
