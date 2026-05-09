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
    [Header("CorrectText")]
    [SerializeField] private Text _coreectText;
    [Header("FadeImage")]
    [SerializeField] private Image _fadeImage;
    [Header("SceneManager")]
    [SerializeField] private SceneMoveManager _sceneM;

    private void Start()
    {
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

    public async UniTask FinishAnim(CancellationToken token)
    {
        _textAnimator.SetTrigger("Finish");
        await UniTask.Delay(TimeSpan.FromSeconds(_finishClip.length), cancellationToken: token);
        await _fadeImage.DOFade(1f, 2f).ToUniTask(cancellationToken: token);
        _sceneM.SceneMove("Result");
    }
}
