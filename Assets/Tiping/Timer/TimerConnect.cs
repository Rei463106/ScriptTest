using UnityEngine;

public class TimerConnect : MonoBehaviour
{
    [Header("TimerUI")]
    [SerializeField] private TimerUI _timerUI;

    public float CurrentTime()
    {
        return _timerUI.ReturnTime();
    }
}
