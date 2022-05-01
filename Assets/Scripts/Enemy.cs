using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<Target>().transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
