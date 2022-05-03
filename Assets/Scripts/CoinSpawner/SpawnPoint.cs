using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _delay;
    [SerializeField] private float _minXPosition;
    [SerializeField] private float _maxXPosition;
    [SerializeField] private bool _isWorking;

    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        StartCoroutine(StartWork());
    }

    private IEnumerator StartWork()
    {
        while (_isWorking)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x + Random.Range(_minXPosition, _maxXPosition), transform.position.y);
            Instantiate(_prefab, spawnPosition, Quaternion.identity);

            yield return _waitForSeconds;
        }
    }
}
