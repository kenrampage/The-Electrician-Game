using UnityEngine;

public class ToggleObjectActive : MonoBehaviour
{
    public GameObject target;

    public void ToggleTargetActive()
    {
        target.gameObject.SetActive(!target.gameObject.activeSelf);
    }
}
