using UnityEngine;
using UnityEngine.Events;

public class PingPongMotion : MonoBehaviour
{
    [SerializeField] private GameObject m_Target;

    [SerializeField]
    private Transform
        m_Start,
        m_End;

    [SerializeField]
    private float
        m_ForwardSpeed,
        m_BackwardSpeed,
        m_StartTimeout = 0.0f;


    private bool m_IsForward;
    private float m_StartTimer;
    public UnityEvent<bool> OnWentForward;

    private void Start()
    {
        m_StartTimer = m_StartTimeout;
    }
    private void Update()
    {
        if (m_StartTimer > 0)
        {
            m_StartTimer -= Time.deltaTime;
            return;
        }

        if (m_IsForward)
        {
            m_Target.transform.position = Vector3.Lerp(m_Target.transform.position, m_End.position, m_ForwardSpeed * Time.deltaTime);
            if (Vector3.Distance(m_Target.transform.position, m_End.position) < 0.5f)
            {
                m_IsForward = false;
                Debug.Log("goin backward");
                OnWentForward?.Invoke(false);
            }

        }
        else
        {
            m_Target.transform.position = Vector3.Lerp(m_Target.transform.position, m_Start.position, m_BackwardSpeed * Time.deltaTime);

            if (Vector3.Distance(m_Target.transform.position, m_Start.position) < 0.5f)
            {
                m_IsForward = true;
                
                OnWentForward?.Invoke(true);


            }
        }

    }
}
