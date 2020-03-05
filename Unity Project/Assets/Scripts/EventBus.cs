using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : Singleton<EventBus>
{
    private Dictionary<string, UnityEvent> m_EventDictionary;
    private static List<string> m_AudioEvent = new List<string>();

    public override void Awake()
    {
        base.Awake();
        Instance.Init();
    }

    private void Init()
    {
        if (Instance.m_EventDictionary == null)
        {
            Instance.m_EventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public static void AddAudioEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            Debug.Log("Adding audio");
            m_AudioEvent.Add(eventName);
        }
    }

    public static void TriggerAudioEvent()
    {
        if(m_AudioEvent.Count >0)
        {
            string currentEvent = m_AudioEvent[0]; 
            UnityEvent thisEvent;
            m_AudioEvent.RemoveAt(0);
            if (Instance.m_EventDictionary.TryGetValue(currentEvent, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}