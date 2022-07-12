using UnityEngine;

public class TargetMarkers : MonoBehaviour
{
    public GameObject redMarker;
    public GameObject greenMarker;

    public void TurnOn()
    {
        redMarker.SetActive(false);
        greenMarker.SetActive(true);
    }

    public void TurnOff()
    {
        redMarker.SetActive(true);
        greenMarker.SetActive(false);
    }
}
