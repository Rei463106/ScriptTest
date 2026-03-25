using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Objects/Data")]
public class Data : ScriptableObject
{
    [SerializeField]
    [TextArea] private string _dfsData;

    public string DFSData => _dfsData;
}
