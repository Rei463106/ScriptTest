using TMPro;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        var x = _text.preferredWidth;
        var y = _text.preferredHeight;
        _rectTransform.anchoredPosition = new Vector2(x, y);
    }
}
