using UnityEngine;

public class TimerConnect : MonoBehaviour
{
    [Header("ingameDirection")]
    [SerializeField] private InGameDirection _direction;
    [Header("制限時間")]
    [SerializeField] private float _limitTime;

    private float _currentTime;
    private bool _isStop = false;

    private void OnEnable()
    {
        EventBus.Subscribe<InitializeEvent>(this, InitializeTime);
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
            EventBus.Publish(new TimerEvent(_currentTime, _limitTime));
        }

        if (_currentTime <= 0 && !_isStop)
        {
            _isStop = true;
            _direction.Finish();
        }
    }

    private void InitializeTime(InitializeEvent i)
    {
        TimerMove._timerEnum = TimerEnum.None;
    }

    private void HandOverTime(FinishEvent f)
    {
        TimerMove._timerEnum = TimerEnum.None;
        StaticResult._finalTime = _limitTime - _currentTime;
    }
}
