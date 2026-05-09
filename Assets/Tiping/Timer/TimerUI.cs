using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [Header("InGameDirection")]
    [SerializeField] private InGameDirection _ingameDirection;
    [Header("時計")]
    [SerializeField] private Image _timerImage;
    [Header("秒針")]
    [SerializeField] private Image _secondHand;

    private void OnEnable()
    {
        EventBus.Subscribe<TimerEvent>(this, TimerCalculate);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    private void TimerCalculate(TimerEvent t)
    {
        //時計
        var ratio = Mathf.Clamp01(t._currentTime / t._limitTime);
        _timerImage.fillAmount = ratio;
        //秒針
        _secondHand.transform.localRotation = Quaternion.Euler(0, 0, 360 * ratio);
    }
}
