using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
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

    public async UniTask StartAnim()
    {
        await UniTask.WhenAll(_fadeImage.DOFade(0f, 2f).ToUniTask());
        _textAnimator.Play("Start");
        await UniTask.Delay(TimeSpan.FromSeconds(_startClip.length));
    }

    public async UniTask CorrectAnim()
    {
        _coreectText.text = "Correct!!";
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _coreectText.text = "";
    }

    public async UniTask FinishAnim()
    {
        _textAnimator.SetTrigger("Finish");
        await UniTask.Delay(TimeSpan.FromSeconds(_finishClip.length));
        await UniTask.WhenAll(_fadeImage.DOFade(1f, 2f).ToUniTask());
        _sceneM.SceneMove("Result");
    }
}
