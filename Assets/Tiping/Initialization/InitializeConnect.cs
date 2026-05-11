using UnityEngine;

public class InitializeConnect : MonoBehaviour
{
    private InitializeRuntime _initializeR;
    private void OnEnable()
    {
        var list = SelectTipeList._tipeList;
        _initializeR = new InitializeRuntime(list);
    }

    public bool GoInitializeExecute()
    {
        if (_initializeR.TipeQueue > 0)
        {
            _initializeR.InitializeExecute();
            return true;
        }
        else
            return false;
    }
}
