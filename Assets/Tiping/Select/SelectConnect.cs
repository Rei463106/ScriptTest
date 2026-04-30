using UnityEngine;

public class SelectConnect : MonoBehaviour
{
    [Header("Node‚ÌƒŠƒXƒg")]
    [SerializeField] private Node _nodeList;
    private SelectRuntime _selectRuntime;

    private void OnEnable()
    {
        _selectRuntime = new SelectRuntime(_nodeList);
    }

    public void RightButton()
    {
        _selectRuntime.RightButton();
    }

    public void LeftButton()
    {
        _selectRuntime.LeftButton();
    }

    public void DecisionButton()
    {
        _selectRuntime.DecisionButton();
    }
}
