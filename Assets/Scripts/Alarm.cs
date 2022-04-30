using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Color _switcedOffColor;
    [SerializeField] private Color _switchedOnCollor;
    [SerializeField] private float _volumeChangeRate;

    private SpriteRenderer _renderer;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private bool _isWorking;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = _switcedOffColor;
        _audioSource.volume = 1;
        _isWorking = false;
    }

    public void Guard()
    {
        if (_isWorking == true)
        {
            _audioSource.Stop();
            _isWorking = false;
            StopCoroutine(VolumeChange());
            _renderer.color = _switcedOffColor;
        }
        else
        {
            _audioSource.Play();
            _isWorking = true;
            StartCoroutine(VolumeChange());
            _renderer.color = _switchedOnCollor;
        }
    }

    private IEnumerator VolumeChange()
    {
        float targetVolume = 1;

        while (_isWorking)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeRate * Time.deltaTime);

            if (_audioSource.volume == targetVolume)
            {
                if (_audioSource.volume == _maxVolume)
                    targetVolume = _minVolume;
                else
                    targetVolume = _maxVolume;
            }
            yield return null;
        }
    }
}
