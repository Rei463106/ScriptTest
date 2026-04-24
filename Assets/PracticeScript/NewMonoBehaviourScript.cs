using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{


    private void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector3(15f, 15f, 0f);
    }
}
