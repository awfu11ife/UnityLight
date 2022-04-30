using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeRate;

    private float _maxVolume = 1;
    private float _minVolume = 0;
    private bool _isWorking;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Play();
            _isWorking = true;
            StartCoroutine(VolumeChange());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Stop();
            _isWorking = false;
            StopCoroutine(VolumeChange());
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
