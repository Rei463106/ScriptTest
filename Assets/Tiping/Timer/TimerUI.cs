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

    private void OnEnable()
    {
        EventBus.Subscribe<FinishEvent>(this, HandOverTime);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    private void Start()
    {
        _currentTime = _limitTime;
    }

    private void Update()
    {
        if (TimerMove._timerEnum == TimerEnum.MoveTime)
        {
            _currentTime -= Time.deltaTime;
            TimerCalculate(_currentTime);

        }
        if (_currentTime < 0)
        {
            EventBus.Publish(new FinishEvent());
        }
    }

    private void TimerCalculate(float currentTime)
    {
        //時計
        var ratio = Mathf.Clamp01(currentTime / _limitTime);
        _timerImage.fillAmount = ratio;
        //秒針
        _secondHand.transform.localRotation = Quaternion.Euler(0, 0, 360 * ratio);
    }

    private void HandOverTime(FinishEvent f)
    {
        StaticResult._finalTime = _currentTime;
    }

    public float ReturnTime()
    {
        return _currentTime;
    }
}
