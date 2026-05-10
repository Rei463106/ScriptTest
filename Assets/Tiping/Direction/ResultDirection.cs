using Cysharp.Threading.Tasks;
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
    [Header("SceneManager")]
    [SerializeField] private SceneMoveManager _sceneM;

    private void Start()
    {
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
        _correctSecond.text = Mathf.RoundToInt(StaticResult._finalTime).ToString();
        await UniTask.Delay(TimeSpan.FromSeconds(2f), cancellationToken: token);
        _correctRank.text = StaticResult._finalRank;

        while (true)
        {
            if (Input.anyKeyDown)
                break;
        }
        _sceneM.SceneMove("TipingTitle");
    }
}
