using UnityEngine;

public class GeneralPanic : MonoBehaviour
{
    private bool m_IsQuitting;

    void OnEnable()
    {
        EventBus.StartListening("Panic", Panic);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Panic", Panic);
        }
    }

    void Panic()
    {
        Debug.Log("Received a panic event : General panic happens!");
    }
}