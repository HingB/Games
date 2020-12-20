using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundValueChanger : MonoBehaviour
{
    [SerializeField] private float _durationOfAlarmActivation;

    private AudioSource _currentAudio;
    private WaitForSeconds _waitForAnySeconds;

    private void Start()
    { 
       _waitForAnySeconds = new WaitForSeconds(_durationOfAlarmActivation / 100);
    }
    public void IncreaseSoundVolume(AudioSource audioSource)
    {
        _currentAudio = audioSource;

        var increaseSound = StartCoroutine(IncreaseSoundVolume());
    }

    public void DecreaseSoundVolume(AudioSource audioSource)
    {
        _currentAudio = audioSource;

        var decreaseSound = StartCoroutine(DecreaseAudioVolume());
    }

    private IEnumerator IncreaseSoundVolume()
    {
        for (float i = 0; i <= 1f; i += 0.01f)
        {
            _currentAudio.volume = 1 * i;

            yield return _waitForAnySeconds;
        }
    }

    private IEnumerator DecreaseAudioVolume()
    {
        for (float i = 1; i >= 0f; i -= 0.01f)
        {
            _currentAudio.volume = 1 * i;

            yield return _waitForAnySeconds;
        }
        _currentAudio.volume = 0;
        _currentAudio.Stop();
    }
}
