using UnityEngine;

namespace RampageUtils
{
    // Toggles active status of this object
    public class ToggleThisObject : MonoBehaviour
    {
        public void SetActive()
        {
            gameObject.SetActive(true);
        }

        public void SetInactive()
        {
            gameObject.SetActive(false);
        }

        public void ToggleActive()
        {
            if(gameObject.activeSelf)
            {
                SetInactive();
            } else
            {
                SetActive();
            }
        }

    }
}
