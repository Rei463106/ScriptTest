using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    [Header("移動するオブジェクト")]
    [SerializeField] private GameObject _player;
    [Header("オブジェクト")]
    [SerializeField] private GameObject[] _objects = new GameObject[3];
    [Header("右ボタン")]
    [SerializeField] private Image _rightButton;
    [Header("左ボタン")]
    [SerializeField] private Image _leftButton;

    private int _currentIndex = 0;

    private void OnEnable()
    {
        SelectButtonEvents._rightAction += RightButton;
        SelectButtonEvents._leftAction += LeftButton;      
    }

    private void OnDisable()
    {
        SelectButtonEvents._rightAction -= RightButton;
        SelectButtonEvents._leftAction -= LeftButton;
    }

    private void Start()
    {
        _player.transform.position = _objects[_currentIndex].transform.position;

        var n = _leftButton.color;
        n.a = 0.5f;
        _leftButton.color = n;
    }

    /// <summary>
    /// 右ボタン
    /// </summary>
    private void RightButton()
    {
        if (_currentIndex < _objects.Length - 1)
        {
            _currentIndex++;
            _player.transform.position = _objects[_currentIndex].transform.position;

            if (_currentIndex == _objects.Length - 1)
            {
                var n = _rightButton.color;
                n.a = 0.5f;
                _rightButton.color = n;
            }//最大値になってたらボタンを半透明にする
            else
            {
                var n = _leftButton.color;
                n.a = 1f;
                _leftButton.color = n;
            }
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// 左ボタン
    /// </summary>
    private void LeftButton()
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            _player.transform.position = _objects[_currentIndex].transform.position;

            if (_currentIndex == 0)
            {
                var n = _leftButton.color;
                n.a = 0.5f;
                _leftButton.color = n;
            }//最大値になってたらボタンを半透明にする
            else
            {
                var n = _rightButton.color;
                n.a = 1f;
                _rightButton.color = n;
            }
        }
        else
        {
            return;
        }
    }
}
