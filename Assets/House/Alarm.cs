using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedSounChangesTime;
    private float _speedSounChangesCurrentTime;

    private AudioSource _audio;
    private bool _haveThief;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0; 
    }

    private void SetVolume(float startVolume, float endVolume, float speedSounChanges)
    {
        _audio.volume = Mathf.Lerp(startVolume, endVolume, speedSounChanges);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Thief")
        {
            _speedSounChangesCurrentTime = 0;
            _haveThief = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Thief")
        {
            _speedSounChangesCurrentTime = 0;
            _haveThief = false;
        }
    }

    private void Update()
    {
        _speedSounChangesCurrentTime += Time.deltaTime;

        if (_haveThief)
        {
            SetVolume(_minVolume, _maxVolume, _speedSounChangesCurrentTime / _speedSounChangesTime);
        }
        else if(_haveThief == false)
        {
            SetVolume(_audio.volume, _minVolume, _speedSounChangesCurrentTime / _speedSounChangesTime);
        } 
    }
}
