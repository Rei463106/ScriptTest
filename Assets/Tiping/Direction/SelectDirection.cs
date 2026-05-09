using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SelectDirection : MonoBehaviour
{
    [Header("SE用")]
    [SerializeField] private AudioSource m_AudioSource;
    [Header("左右ボタン")]
    [SerializeField] private AudioClip _selectClip;
    [Header("決定ボタン")]
    [SerializeField] private AudioClip _dicisionClip;
    [Header("FadeImage")]
    [SerializeField] private Image _fadeImage;
    [Header("SceneMove")]
    [SerializeField] private SceneMoveManager _sceneM;

    private CancellationToken _token;

    private void OnEnable()
    {
        SelectButtonEvents._rightAction += SelectSound;
        SelectButtonEvents._leftAction += SelectSound;
        SelectButtonEvents._dicisionAction += DicisionSound;
    }

    private void OnDisable()
    {
        SelectButtonEvents._rightAction -= SelectSound;
        SelectButtonEvents._leftAction -= SelectSound;
        SelectButtonEvents._dicisionAction -= DicisionSound;
    }

    private void Start()
    {
        _token = this.GetCancellationTokenOnDestroy();
        StartAnim(_token).Forget();

    }

    private void SelectSound()
    {
        m_AudioSource.PlayOneShot(_selectClip);
    }

    private void DicisionSound()
    {
        m_AudioSource.PlayOneShot(_dicisionClip);
        FinishAnim(_token).Forget();
    }

    private async UniTask StartAnim(CancellationToken token)
    {
        await _fadeImage.DOFade(0f, 2f).ToUniTask(cancellationToken: token);
    }

    private async UniTask FinishAnim(CancellationToken token)
    {
        await _fadeImage.DOFade(1f, 2f).ToUniTask(cancellationToken: token);
        _sceneM.SceneMove("TipingGame");
    }
}
