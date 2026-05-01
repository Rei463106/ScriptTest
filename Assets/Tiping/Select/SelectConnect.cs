using UnityEngine;

public class SelectConnect : MonoBehaviour
{
    [Header("Nodeのリスト")]
    [SerializeField] private Node _nodeList;
    [SerializeField] private SceneMoveManager _moveManager;
    private SelectRuntime _selectRuntime;

    private void OnEnable()
    {
        _selectRuntime = new SelectRuntime(_nodeList);
    }

    private void Update()
    {
        Debug.Log(SelectTipeList._tipeList);
        if (Input.GetKeyDown(KeyCode.Z))
            DicisionButton();
    }

    public void RightButton()
    {
        _selectRuntime.RightButton();
    }

    public void LeftButton()
    {
        _selectRuntime.LeftButton();
    }

    public void DicisionButton()
    {
        _selectRuntime.DecisionButton();
        _moveManager.SceneMove("TipingGame");
    }
}
