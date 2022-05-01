using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSwitcher : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private bool _isWorking;

    private Spawner[] _allSpawners;

    private void Awake()
    {
        _allSpawners = FindObjectsOfType<Spawner>();
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

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
