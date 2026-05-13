using TMPro;
using UnityEngine;

public class InitializeUI : MonoBehaviour
{
    [Header("ひらがなテキスト")]
    [SerializeField] private TextMeshProUGUI _kanaText;
    [Header("ローマ字テキスト")]
    [SerializeField] private TextMeshProUGUI _romaText;
    [Header("答えローマ字テキスト")]
    [SerializeField] private TextMeshProUGUI _answerRomaText;

    private void OnEnable()
    {
        EventBus.Subscribe<InitializeEvent>(this, ChangeColor);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);//ここのイベント全てを解除
    }

    /// <summary>
    /// 初期化で文字の色変え
    /// </summary>
    /// <param name="e"></param>
    private void ChangeColor(InitializeEvent e)
    {
        _kanaText.text = e._tipeName.KanaName;
        _answerRomaText.text = e._tipeName.Name;
        _romaText.text = "";//ローマ字のは空にする
        _kanaText.color = Color.black;
        _romaText.color = Color.black;
        _answerRomaText.color = Color.black;
    }
}
