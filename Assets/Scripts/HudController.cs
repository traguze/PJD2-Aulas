using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Text TimerText;
    private void Awake()
    {
        TimerText = gameObject.GetComponentInChildren<Text>();

        GameEvents.OnGenericEvent.AddListener(EventListener);

        //GameEvents.OnElapsedTime.AddListener(UpdateElapsedTime);
        GameEvents.OnElapsedTime.AddListener((float time) =>
        {
            SetTimerText(time);
        });
    }

    private void UpdateElapsedTime(float time)
    {
        SetTimerText(time);
    }

    private void EventListener()
    {
        Debug.Log("EventListener");
    }

    public void SetTimerText(string str)
    {
        TimerText.text = str;
    }

    public void SetTimerText(float time)
    {
        TimerText.text = time.ToString();
    }
}
