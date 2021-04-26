using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventListener : MonoBehaviour
{
    [SerializeField]
    private UnityEvent[] events;

    public void EventCall(int index)
    {
        if(events.Length > index)
        {
            events[index].Invoke();
        }
        else
        {
            Debug.Log("NO index");
        }
    }
}
