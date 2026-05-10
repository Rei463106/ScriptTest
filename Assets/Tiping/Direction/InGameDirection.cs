using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class InGameDirection : MonoBehaviour
{
    [Header("TextAnimator")]
    [SerializeField] private Animator _textAnimator;
    [Header("StartClip")]
    [SerializeField] private AnimationClip _startClip;
    [Header("FinishClip")]
    [SerializeField] private AnimationClip _finishClip;
    [Header("animText")]
    [SerializeField] private Text _animText;
    [Header("CorrectText")]
    [SerializeField] private Text _coreectText;
    [Header("FadeImage")]
    [SerializeField] private Image _fadeImage;
    [Header("SceneManager")]
    [SerializeField] private SceneMoveManager _sceneM;

    private CancellationToken _token;

    private void Start()
    {
        _token = this.GetCancellationTokenOnDestroy();
        _coreectText.text = "";
    }

    public async UniTask StartAnim(CancellationToken token)
    {
        await _fadeImage.DOFade(0f, 3f).ToUniTask(cancellationToken: token);
        _textAnimator.Play("Start");
        await UniTask.Delay(TimeSpan.FromSeconds(_startClip.length), cancellationToken: token);
    }

    public async UniTask CorrectAnim(CancellationToken token)
    {
        _coreectText.text = "Correct!!";
        await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
        _coreectText.text = "";
    }

    private async UniTask FinishAnim(CancellationToken token)
    {
        _animText.text = "Finish!!";
        _textAnimator.SetTrigger("Finish");
        await UniTask.Delay(TimeSpan.FromSeconds(_finishClip.length), cancellationToken: token);
        await _fadeImage.DOFade(1f, 2f).ToUniTask(cancellationToken: token);
        _sceneM.SceneMove("Result");
    }

    private async UniTask WaitFinish()
    {
        //ゲーム終了     
        EventBus.Publish(new FinishEvent());
        await FinishAnim(_token);
    }

    public void Finish()
    {
        WaitFinish().Forget();
    }
}
