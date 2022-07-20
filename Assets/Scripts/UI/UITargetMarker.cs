using UnityEngine;

public class UITargetMarker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject redMarker;
    [SerializeField] private GameObject greenMarker;

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
