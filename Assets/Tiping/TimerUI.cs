using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [Header("時計")]
    [SerializeField] private Image _timerImage;
    [Header("秒針")]
    [SerializeField] private Image _secondHand;
    [Header("制限時間")]
    [SerializeField] private float _limitTime;
    private float _currentTime;
  
    private void Start()
    {
        _currentTime = _limitTime;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        TimerCalculate(_currentTime);
    }

    private void TimerCalculate(float currentTime)
    {
        //時計
        var ratio = Mathf.Clamp01(currentTime / _limitTime);
        _timerImage.fillAmount = ratio;
        //秒針
        _secondHand.transform.localRotation = Quaternion.Euler(0, 0, 360 * ratio);
    }
}
