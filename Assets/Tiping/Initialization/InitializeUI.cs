using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitializeUI : MonoBehaviour
{
    [Header("ひらがなテキスト")]
    [SerializeField] private TextMeshProUGUI _kanaText;
    [Header("ローマ字テキスト")]
    [SerializeField] private TextMeshProUGUI _romaText;

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
        _romaText.text = "";//ローマ字のは空にする
        _kanaText.color = Color.white;
        _romaText.color = Color.white;
    }
}
