using UnityEngine;
using FMODUnity;

public class FMODPlayOneShot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EventReference fmodEvent;

    [Header("Settings")]
    [SerializeField] private bool soundEffectsOn = true;
    private bool is3D;

    private void Awake()
    {
        RuntimeManager.GetEventDescription(fmodEvent).is3D(out is3D);
    }

    public void Play()
    {
        if (soundEffectsOn)
        {
            RuntimeManager.PlayOneShot(fmodEvent, gameObject.transform.position);

            if (is3D)
            {
                PlayAttached(this.gameObject);
            }
            else
            {
                RuntimeManager.PlayOneShot(fmodEvent);
            }
        }

    }

    public void PlayAttached(GameObject obj)
    {
        if (soundEffectsOn)
        {
            RuntimeManager.PlayOneShotAttached(fmodEvent, obj);
        }

    }

    public void DisableSoundEffects()
    {
        soundEffectsOn = false;
    }

    public void EnableSoundEffects()
    {
        soundEffectsOn = true;
    }

}
