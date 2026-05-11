using UnityEngine;

public class InitializeConnect : MonoBehaviour
{
    private InitializeRuntime _initializeR;
    private void OnEnable()
    {
        var list = SelectTipeList._tipeList;
        _initializeR = new InitializeRuntime(list);
    }

    public int GoInitializeExecute()
    {
        if (_initializeR.TipeQueue > 0)
        {
            _initializeR.InitializeExecute();
            return 1;
        }
        else
            return -1;
    }
}
