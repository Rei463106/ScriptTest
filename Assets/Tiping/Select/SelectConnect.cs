using UnityEngine;

public class SelectConnect : MonoBehaviour
{
    [Header("Nodeのリスト")]
    [SerializeField] private Node _nodeList;
   
    private SelectRuntime _selectRuntime;

    private void OnEnable()
    {
        _selectRuntime = new SelectRuntime(_nodeList);
        SelectButtonEvents._rightAction += RightButton;
        SelectButtonEvents._leftAction += LeftButton;
        SelectButtonEvents._dicisionAction += DicisionButton;
    }

    private void OnDisable()
    {
        SelectButtonEvents._rightAction -= RightButton;
        SelectButtonEvents._leftAction -= LeftButton;
        SelectButtonEvents._dicisionAction -= DicisionButton;
    }

    private void Update()
    {
        Debug.Log(SelectTipeList._tipeList);
        if (Input.GetKeyDown(KeyCode.Z))
            SelectButtonEvents.DicisionAction();
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
    }
}
