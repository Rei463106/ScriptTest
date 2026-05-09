using Cysharp.Threading.Tasks;
using System;
using System.Threading;
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

    private void Start()
    {
        var ct = this.GetCancellationTokenOnDestroy();
        BlinkCursor(ct).Forget();
    }

    private void Update()
    {
        MoveCursor();
    }

    private async UniTask BlinkCursor(CancellationToken token)
    {
        while (i == 0)
        {
            _cursor.enabled = true;
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);
            _cursor.enabled = false;
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

            await UniTask.Yield();
        }
    }

    private void MoveCursor()
    {
        _romaText.ForceMeshUpdate();

        var textInfo = _romaText.textInfo;

        if (textInfo.characterCount == 0)
        {
            _cursorTransform.anchoredPosition = _cursorInitializeOffset;
            return;
        }

        var charInfo = textInfo.characterInfo[textInfo.characterCount - 1];
        float x = charInfo.xAdvance;
        float y = charInfo.baseLine;
        Vector3 change = new Vector3(x, y, 0);

        // ① TMPローカル → ワールド
        Vector3 worldPos = _romaText.transform.TransformPoint(change);

        // ② ワールド → スクリーン
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, worldPos);

        // ③ スクリーン → Canvasローカル
        RectTransform canvasRect = _cursorTransform.root as RectTransform;

        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPos,
            null,
            out localPos
        );

        // 最終的に適用
        _cursorTransform.anchoredPosition = localPos;
    }
}
