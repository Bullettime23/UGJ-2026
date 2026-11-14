using CodeBase.DamageSystem;
using LevGamekit.Infrastructure.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UINote : MonoBehaviour, IUINote
{
    [SerializeField] private RectTransform m_NoteBackground;
    [SerializeField] private TextMeshProUGUI m_NoteText;

    public bool IsOpen { get; private set; }


    private void Start()
    {
        Hide();
        IsOpen = false;
    }

    public void ShowMessage(string message)
    {
        m_NoteText.text = message;
        m_NoteBackground.gameObject.SetActive(true);

        IsOpen = true;

    }

    public void Hide()
    {
        m_NoteBackground.gameObject.SetActive(false);

        IsOpen = false;

    }


}
