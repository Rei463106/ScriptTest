using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトル時の演出
/// </summary>
public class TitleDirection : MonoBehaviour
{
    [Header("Fade")]
    [SerializeField] private Image _fadeImage;
    [Header("SE用")]
    [SerializeField] private AudioSource _seSource;
    [Header("決定音")]
    [SerializeField] private AudioClip _dicisionClip;
    [Header("SceneManager")]
    [SerializeField] private SceneMoveManager _sceneM;

    private void Start()
    {
        _fadeImage.DOFade(0f, 0f);
        var token = this.GetCancellationTokenOnDestroy();
        TitleAnim(token).Forget();
    }

    private async UniTask TitleAnim(CancellationToken token)
    {
        await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Z), cancellationToken: token);
        _seSource.PlayOneShot(_dicisionClip);
        await _fadeImage.DOFade(1f, 2f).ToUniTask(cancellationToken: token);
        _sceneM.SceneMove("TipingsSelect");
    }
}
