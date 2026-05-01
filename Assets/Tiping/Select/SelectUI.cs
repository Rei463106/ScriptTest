using UnityEngine;

public class SelectUI : MonoBehaviour
{
    [Header("移動するオブジェクト")]
    [SerializeField] private GameObject _player;
    [Header("オブジェクト")]
    [SerializeField] private GameObject[] _objects = new GameObject[3];
    private int _currentIndex = 0;

    private void Start()
    {
        _player.transform.position = _objects[_currentIndex].transform.position;
    }

    /// <summary>
    /// 右ボタン
    /// </summary>
    public void RightButton()
    {
        if (_currentIndex < _objects.Length - 1)
        {
            _currentIndex++;
            _player.transform.position = _objects[_currentIndex].transform.position;
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// 左ボタン
    /// </summary>
    public void LeftButton()
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            _player.transform.position = _objects[_currentIndex].transform.position;
        }
        else
        { 
            return;
        }
    }
}
