using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventBus.TriggerEvent("Shoot");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            EventBus.TriggerEvent("Launch");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            EventBus.TriggerEvent("Surrender");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            EventBus.TriggerEvent("Fire");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            EventBus.TriggerEvent("Panic");
        }

        if(Input.GetKey(KeyCode.Y))
        {
            Debug.Log("   Event Pub adding audio");
            EventBus.AddAudioEvent("Audio");
        }

        if((int)Time.time % 8 == 0)
        {
            Debug.Log("   Trying to trigger audio");
            EventBus.TriggerAudioEvent();
        }
    }

    //game instructions
    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 500, 20), "S - Shoot Cannon");
        GUI.Label(new Rect(10, 25, 500, 20), "L - Launch Rocket (Only once)");
        GUI.Label(new Rect(10, 40, 500, 20), "W - Surrender (Only once)");
        GUI.Label(new Rect(10, 55, 500, 20), "M - Fire Missile");
        GUI.Label(new Rect(10, 70, 500, 20), "P - General Panic");
        GUI.Label(new Rect(10, 85, 500, 20), "Output is in Debug.Log!");
    }
}