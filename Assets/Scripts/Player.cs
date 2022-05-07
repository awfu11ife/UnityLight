using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public UnityEvent HealthChange;

    private const string TakeDamageTrigger = "TakeDamage";
    private const string HealTrigger = "Heal";
    private const string IsDiedBool = "IsDied";

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _healValue;

    private int _minHealth = 0;
    private Animator _animator;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
            _currentHealth -= damage;
            _animator.SetTrigger(TakeDamageTrigger);
            HealthChange?.Invoke();       

        if (_currentHealth == _minHealth)
            _animator.SetBool(IsDiedBool, true);
    }

    public void Heal()
    {
        if (_currentHealth != _maxHealth && _currentHealth != _minHealth)
        {          
                _currentHealth += _healValue;
                _animator.SetTrigger(HealTrigger);
                HealthChange?.Invoke();           
        }
    }
}

