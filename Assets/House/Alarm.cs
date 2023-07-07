using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedSounChangesTime;

    private AudioSource _audio;
    private bool _haveThief;

    private float _minVolume = 0f;
    private float _maxVolume = 1.5f;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0; 
    }

    private void SetVolume(float startVolume, float endVolume)
    {
        _audio.volume = Mathf.MoveTowards(startVolume, endVolume, _speedSounChangesTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.TryGetComponent<Controller>(out Controller controller))
        {
            _haveThief = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.TryGetComponent<Controller>(out Controller controller))
        {
            _haveThief = false;
        }
    }

    private void Update()
    {
        if (_haveThief)
        {
            SetVolume(_audio.volume, _maxVolume);
        }
        else if (_haveThief == false)
        {
            SetVolume(_audio.volume, _minVolume);
        }
    }
}
