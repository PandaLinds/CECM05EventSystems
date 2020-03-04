using UnityEngine;

public class WhiteFlag : MonoBehaviour
{
    private bool m_IsQuitting;
    private bool m_HaveSurrendered = false;

    void OnEnable()
    {
        EventBus.StartListening("Surrender", RiseFlag);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Surrender", RiseFlag);
        }
    }

    void RiseFlag()
    {
        if (m_HaveSurrendered == false)
        {
            m_HaveSurrendered = true;
            Debug.Log("Received surrender event : Rising white flag.");
        }
    }
}