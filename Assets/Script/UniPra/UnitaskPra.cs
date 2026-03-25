using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitaskPra : MonoBehaviour
{
    [Header("クリックテキスト")]
    [SerializeField] private Text _text;
    private bool _isClicked = false;

    private void Start()
    {
        ColorChange().Forget();//待たない時はForget()
        ClickCheck().Forget();
    }

    private void Update()
    {
      if(Input.GetMouseButtonDown(0))
        {
            _isClicked = true;
        }
    }

    /// <summary>
    /// 三秒後に色を変える
    /// </summary>
    /// <returns></returns>
    private async UniTask ColorChange()
    {
        Color a = Color.blue;
        Color c = Color.red;
        this.GetComponent<SpriteRenderer>().color = a;
        await UniTask.Delay(TimeSpan.FromSeconds(3f));
        this.GetComponent<SpriteRenderer>().color = c;
    }

    /// <summary>
    /// _isClickedがtrueになるまで待機する
    /// </summary>
    /// <returns></returns>
    private async UniTask ClickCheck()
    {
        await UniTask.WaitUntil(() => _isClicked);
        _text.text = "クリックされました";
    }
}
