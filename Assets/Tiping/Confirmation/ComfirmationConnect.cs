using UnityEngine;

public class ComfirmationConnect : MonoBehaviour
{
    private ComfirationRuntime _comfirmationR;
    private char _currentChar;//Œ»İ‚Ì•¶š‚ğ“ü‚ê‚é

    private void OnEnable()
    {
        EventBus.Subscribe<InitializeEvent>(this, InstatiateRuntime);
        EventBus.Subscribe<ConfirmationEvent>(this, Confirmation);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    public int ReturnCount()
    {
        return _comfirmationR.ReturnQueueCount();
    }

    /// <summary>
    /// ‚±‚ê‚à‰Šú‰»‚Ì’†‚É“ü‚ê‚é
    /// </summary>
    /// <param name="tipeName"></param>
    private void InstatiateRuntime(InitializeEvent e)
    {
        _comfirmationR = new ComfirationRuntime(e._tipeName);
        _currentChar = _comfirmationR.InitializeComfirmation();//ˆê•¶š–Ú‚ğ“ü‚ê‚é
    }

    /// <summary>
    /// “ü—Í‚³‚ê‚½•¶š‚ª‡‚Á‚Ä‚¢‚é‚©ŠÔˆá‚Á‚Ä‚¢‚é‚©‚ÅÀs
    /// Input‚Ì•û‚ÅŒÄ‚Ño‚µ
    /// </summary>
    /// <param name="input"></param>
    private void Confirmation(ConfirmationEvent c)
    {
        if (c._inputChar == _currentChar)
        {
            EventBus.Publish(new CorrectEvent());
        }
        else
        {
            EventBus.Publish(new InCorrectEvent());
        }
    }
}
