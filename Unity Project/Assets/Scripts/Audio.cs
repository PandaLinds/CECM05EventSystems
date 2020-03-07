using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

// make queue in here instead

public class Audio : MonoBehaviour
{
    private static List<string> m_AudioEvent = new List<string>();
    private bool m_IsQuitting;
    private static bool call = false;

    void Start()
    {
        InvokeRepeating("TriggerAudioEvent", 3.0f, 3.0f);
    }

    void OnEnable()
    {
        EventBus.StartListening("Audio", AddAudioEvent);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Audio", AddAudioEvent);
        }
    }

    void Update()
    {
        //invoke with function name & time
        //time.time % 3 w/ bool
        //TriggerAudioEvent();
    }

    void PlayAudio()
    {
        Debug.Log("AUDIO");
    }

    void AddAudioEvent()//string eventName)
    {
        m_AudioEvent.Add("Audio");
    }

    public void TriggerAudioEvent()
    {
        if (m_AudioEvent.Count > 0)
        {
            string currentEvent = m_AudioEvent[0];
            m_AudioEvent.RemoveAt(0);
            PlayAudio();
        }
    }
}