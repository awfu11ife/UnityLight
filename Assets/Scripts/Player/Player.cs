using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damade)
    {
        if (damade > 0)
        {
            _health -= damade;
            Debug.Log($"Текущее здоровье - {_health}");
        }

        if (_health <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("GAME OVER");
        }
    }
}
