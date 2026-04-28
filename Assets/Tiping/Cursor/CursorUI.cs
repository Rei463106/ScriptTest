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
    [Header("初期位置")]
    [SerializeField] private Vector2 _cursorInitializeOffset;

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
        MoveCursor();   
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
        //MoveCursor();
    }

    /// <summary>
    /// 正解時にカーソルを動かす
    /// </summary>
    /// <param name="c"></param>
    private void CorrectCursor(CorrectEvent c)
    {
        //MoveCursor();
    }

    private void MoveCursor()
    {
        if (_romaText.text.Length == 0)
            _cursorTransform.anchoredPosition = _cursorInitializeOffset;
        else
        {
            var currentString = _romaText.textInfo.characterInfo;
            var lastString = currentString[_romaText.text.Length - 1].bottomRight;
            var x = lastString.x;
            var y = lastString.y;
            _cursorTransform.anchoredPosition = new Vector2(x, y);
        }     
    }
}
