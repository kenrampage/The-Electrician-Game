using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerMainMenu : MonoBehaviour
{
    [SerializeField] private SOSessionData _sessionData;
    [SerializeField] private SOFMODMusicData _musicData;

    private void Start()
    {
        SetMusicSection();
        // StartMusic();
    }

    private void SetMusicSection()
    {
        if (_sessionData.GetSplashScreenStatus())
        {
            _musicData.SetSection(0);
        }
        else
        {
            _musicData.SetSection(1);
        }
    }

    private void StartMusic()
    {
        _musicData.StartPlayback();
    }
}
