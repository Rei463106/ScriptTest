using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ResultDirection : MonoBehaviour
{
    [Header("ResultClip")]
    [SerializeField] private VideoClip _clip;
    [Header("Menu")]
    [SerializeField] private Text[] _menuText;
    [Header("CorrectNumber")]
    [SerializeField] private Text _correctNumber;
    [Header("CorrectMinute")]
    [SerializeField] private Text _correctMinute;
    [Header("CorrectSecond")]
    [SerializeField] private Text _correctSecond;
    [Header("CorrectRank")]
    [SerializeField] private Text _correctRank;
    [Header("ToTitleText")]
    [SerializeField] private Text _toGoTitleText;
    [Header("Fade")]
    [SerializeField] private Image _fade;
    [Header("SESourse")]
    [SerializeField] private AudioSource _seSource;
    [Header("決定音")]
    [SerializeField] private AudioClip _dicisionClip;
    [Header("SceneManager")]
    [SerializeField] private SceneMoveManager _sceneM;

    private void Start()
    {
        _fade.DOFade(0f, 0f);
        _toGoTitleText.DOFade(0f, 0f);
        var ct = this.GetCancellationTokenOnDestroy();
        Result(ct).Forget();
    }

    private async UniTask Result(CancellationToken token)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_clip.length), cancellationToken: token);
        foreach (var item in _menuText)
        {
            var i = item.color;
            i.a = 1f;
            item.color = i;
        }
        _correctNumber.text = StaticResult._finalCount.ToString();
        await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
        _correctMinute.text = "00";
        var m = Mathf.RoundToInt(StaticResult._finalTime).ToString();
        _correctSecond.text = m.Length == 1 ? "0" + m : m;
        await UniTask.Delay(TimeSpan.FromSeconds(2f), cancellationToken: token);
        _correctRank.text = StaticResult._finalRank;
        await _toGoTitleText.DOFade(1f, 0f).ToUniTask(cancellationToken: token);

        await UniTask.WaitUntil(() => Input.anyKeyDown, cancellationToken: token);
        _seSource.PlayOneShot(_dicisionClip);
        await _fade.DOFade(1f, 2f).ToUniTask(cancellationToken: token);
        _sceneM.SceneMove("TipingTitle");
    }
}
