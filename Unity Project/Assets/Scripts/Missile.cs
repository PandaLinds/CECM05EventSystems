using UnityEngine;

public class Missile : MonoBehaviour
{
    private bool m_IsQuitting;

    void OnEnable()
    {
        EventBus.StartListening("Fire", fireMissile);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Fire", fireMissile);
        }
    }

    void fireMissile()
    {
        Debug.Log("Received a fire missle event : Firing Missile!");
    }
}