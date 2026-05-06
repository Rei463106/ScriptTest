using UnityEngine;

public class SelectDirection : MonoBehaviour
{
    [Header("SE用")]
    [SerializeField] private AudioSource m_AudioSource;
    [Header("左右ボタン")]
    [SerializeField] private AudioClip _selectClip;
    [Header("決定ボタン")]
    [SerializeField] private AudioClip _dicisionClip;
  
    private void OnEnable()
    {
        SelectButtonEvents._rightAction += SelectSound;
        SelectButtonEvents._leftAction += SelectSound;
        SelectButtonEvents._dicisionAction += DicisionSound;
    }

    private void OnDisable()
    {
        SelectButtonEvents._rightAction -= SelectSound;
        SelectButtonEvents._leftAction -= SelectSound;
        SelectButtonEvents._dicisionAction -= DicisionSound;
    }

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void SelectSound()
    {
        m_AudioSource.PlayOneShot(_selectClip);
    }

    private void DicisionSound()
    {
        m_AudioSource.PlayOneShot(_dicisionClip);
    }
}
