using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

/// <summary>
/// タイトル時の演出
/// </summary>
public class TitleDirection : MonoBehaviour
{
    [Header("タイトルAnimator")]
    [SerializeField] private Animator _titleAnimator;
    [Header("シーン遷移Animator")]
    [SerializeField] private Animator _sceneAnimator;
    [Header("タイトル")]
    [SerializeField] private GameObject _titleObject;
    [Header("タイトル前のAnimationClip")]
    [SerializeField] private AnimationClip _clip;
    [Header("SE用")]
    [SerializeField] private AudioSource _seSource;
    [Header("指パッチン")]
    [SerializeField] private AudioClip _patchClip;
    [Header("BGM")]
    [SerializeField] private AudioClip _bgmClip;
    [Header("決定音")]
    [SerializeField] private AudioClip _scenePatchClip;
   
    private AudioSource _source;
    private CancellationTokenSource _token;
    private bool _isPush = false;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _token = new CancellationTokenSource();
        Title(_token.Token).Forget();
    }

    private void Update()
    {
        if (_isPush && Input.anyKeyDown)
            _token.Cancel();
    }

    private async UniTask Title(CancellationToken token)
    {
        _seSource.PlayOneShot(_patchClip);
        _titleAnimator.SetTrigger("Movie");
        _isPush = true;
        bool push = true;
        try
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_clip.length), cancellationToken: token);
            _isPush = false;
        }
        catch (OperationCanceledException)
        {
            Debug.Log("キャンセルされました");
            _titleAnimator.gameObject.SetActive(false);
        }
        finally
        {
            _titleAnimator.gameObject.SetActive(false);
            _source.clip = _bgmClip;
            _source.Play();
        }

        while (push)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _seSource.PlayOneShot(_scenePatchClip);
                Debug.Log("再生");
                push = false;
                _sceneAnimator.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1000;
                _sceneAnimator.SetTrigger("Move");
            }
            await UniTask.Yield();
        }
    }

}
