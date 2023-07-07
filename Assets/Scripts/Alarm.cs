using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedSounChangesTime;
    [SerializeField] private float _timeDelay;

    private AudioSource _audio;
    private float _minValue = -1f;
    private float _maxValue = 1.5f;

    public IEnumerator SetVolume(bool haveThief)
    {
        float endingVolume;
        var waitForDelaySecond = new WaitForSeconds(_timeDelay);

        if (haveThief)
            endingVolume = _maxValue;
        else
            endingVolume = _minValue;

        while (_audio.volume != endingVolume)
        {
            _audio.volume = Mathf.Lerp(_audio.volume, endingVolume, _speedSounChangesTime);
            yield return waitForDelaySecond;
        }
    }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0; 
    }
}
