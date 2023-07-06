using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedSounChangesTime;
    private float _speedSounChangesCurrentTime;

    private AudioSource _audio;
    private bool _haveThief;

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
        _speedSounChangesCurrentTime = 0;
        _haveThief = true;
    }


    private void OnTriggerExit2D(Collider2D collision) 
    {
        _speedSounChangesCurrentTime = 0;
        _haveThief = false;
    }
    

    private void Update()
    {
        _speedSounChangesCurrentTime += Time.deltaTime;

        if (_haveThief)
        {
            SetVolume(0, 1, _speedSounChangesCurrentTime / _speedSounChangesTime);
        }
        else if(_haveThief == false)
        {
            SetVolume(_audio.volume, 0, _speedSounChangesCurrentTime / _speedSounChangesTime);
        } 
    }
}
