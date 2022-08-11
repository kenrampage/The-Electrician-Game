using UnityEngine;

// For swapping visuals on target markers in game ui
public class UITargetMarker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _offMarker;
    [SerializeField] private GameObject _onMarker;

    public void TurnOn()
    {
        _offMarker.SetActive(false);
        _onMarker.SetActive(true);
    }

    public void TurnOff()
    {
        _offMarker.SetActive(true);
        _onMarker.SetActive(false);
    }
}
