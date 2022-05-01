using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    public void Spawn()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity);
    }
}
