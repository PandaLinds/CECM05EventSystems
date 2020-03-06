using UnityEngine;

public class Audio : MonoBehaviour
{
    private bool m_IsQuitting;

    void OnEnable()
    {
        EventBus.StartListening("Audio", PlayAudio);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Audio", PlayAudio);
        }
    }

    void Update()
    {
        EventBus.TriggerAudioEvent();
    }

    void PlayAudio()
    {
        Debug.Log("AUDIO");
    }
}