using Cysharp.Threading.Tasks;
using System.Threading;
using DG.Tweening;
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
    [Header("指パッチン")]
    [SerializeField] private AudioClip _patchClip;
    [Header("BGM")]
    [SerializeField] private AudioClip _bgmClip;
    [Header("決定音")]
    [SerializeField] private AudioClip _scenePatchClip;
    [Header("SceneManager")]
    [SerializeField] private SceneMoveManager _sceneM;

    private AudioSource _source;
    private CancellationToken _token;

    private void Start()
    {
        _fadeImage.DOFade(0f, 0f);
        _source = GetComponent<AudioSource>();
        _token = this.GetCancellationTokenOnDestroy();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
            FinishAnim(_token).Forget();
    }

    private async UniTask FinishAnim(CancellationToken token)
    {
        await _fadeImage.DOFade(1f, 2f).ToUniTask(cancellationToken: token);
        _sceneM.SceneMove("TipingsSelect");
    }

}
