using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundValueChanger : MonoBehaviour
{
    [SerializeField] private float _durationOfAlarmActivation;

    private AudioSource _currentAudio;
    private StateOfSound _stateOfCurrentSound;

    private void Start()
    {
        _stateOfCurrentSound = StateOfSound.Empty;
    }

    private void Update()
    {
        if (_stateOfCurrentSound == StateOfSound.Increase)
            _currentAudio.volume = Mathf.MoveTowards(_currentAudio.volume, 1, _durationOfAlarmActivation * Time.deltaTime);
        else if (_stateOfCurrentSound == StateOfSound.Decrease)
            _currentAudio.volume = Mathf.MoveTowards(_currentAudio.volume, 0, _durationOfAlarmActivation * Time.deltaTime);

    }

    public void IncreaseSoundVolume(AudioSource audioSource)
    {
        _stateOfCurrentSound = StateOfSound.Increase;

        _currentAudio = audioSource;
    }

    public void DecreaseSoundVolume(AudioSource audioSource)
    {
        _stateOfCurrentSound = StateOfSound.Decrease;

        _currentAudio = audioSource;
    }
}
enum StateOfSound
{
    Decrease,
    Increase,
    Empty
}
