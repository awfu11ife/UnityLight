using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSwitcher : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private bool _isWorking;

    private SpawnPoint[] _allSpawners;
    private WaitForSeconds _delayWait;

    private void Awake()
    {
        _allSpawners = FindObjectsOfType<SpawnPoint>();
        _delayWait = new WaitForSeconds (_spawnDelay);
    }

    private void Start()
    {
        StartCoroutine(StartWork());
    }

    private IEnumerator StartWork()
    {
        while (_isWorking)
        {
            int randomSpawnerNumber = Random.Range(0, _allSpawners.Length);
            _allSpawners[randomSpawnerNumber].Spawn();

            yield return _delayWait;
        }
    }
}
