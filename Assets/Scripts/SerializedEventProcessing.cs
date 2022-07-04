using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializedEventProcessing : MonoBehaviour
{
    [NonReorderable]
    [SerializeField] private SerializedEvents[] events;


    [ContextMenu("Cycle Through Events")]
    public void StartCycleThroughEvents()
    {
        StartCoroutine(CycleThroughEvents());
    }

    private IEnumerator CycleThroughEvents()
    {
        for (int i = 0; i < events.Length; i++)
        {

            if (i == events.Length - 1)
            {
                print("End of Events Array");
            }
            else
            {
                print("Waiting " + events[i].delay + " seconds before invoking event at index " + i);
            }

            yield return new WaitForSecondsRealtime(events[i].delay);

            events[i].InvokeEvent();

        }
    }
}
