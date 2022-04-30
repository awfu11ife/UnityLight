using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _rightDirection = 1;
    private int _leftDirection = -1;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(_rightDirection);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(_leftDirection);
        }
    }

    private void Move(int direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
    }
}
