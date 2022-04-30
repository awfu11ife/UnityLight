using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-1);
        }
    }

    private void Move(int direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
    }
}
