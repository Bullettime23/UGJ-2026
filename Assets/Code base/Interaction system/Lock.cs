using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private GameObject
        m_ClosedLock,
        m_OpenedLock;
    public bool IsOpen = false;

    private void Start()
    {
        m_ClosedLock.SetActive(true);
        m_OpenedLock.SetActive(false);
    }

    private void Update()
    {
        if (IsOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down * 5, 0.2f * Time.deltaTime);
        }
    }
    public void OpenLock()
    {
        m_ClosedLock.SetActive(false);
        m_OpenedLock.SetActive(true);
        IsOpen = true;

        Destroy(gameObject, 1);
    }
}
