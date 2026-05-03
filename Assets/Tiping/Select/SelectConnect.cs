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
        SelectButtonEvents._rightAction += RightButton;
        SelectButtonEvents._leftAction += LeftButton;
    }

    private void OnDisable()
    {
        SelectButtonEvents._rightAction -= RightButton;
        SelectButtonEvents._leftAction -= LeftButton;
    }

    private void Update()
    {
        Debug.Log(SelectTipeList._tipeList);
        if (Input.GetKeyDown(KeyCode.Z))
            DicisionButton();
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            SelectButtonEvents.RightAction();
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            SelectButtonEvents.LeftAction();
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
