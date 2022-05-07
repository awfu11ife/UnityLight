using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string TakeDamageTrigger = "TakeDamage";
    private const string HealTrigger = "Heal";
    private const string IsDiedBool = "IsDied";

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _healValue;

    private UnityEvent _healthChanged = new UnityEvent();
    private int _minHealth = 0;
    private Animator _animator;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public int CurrentHealth => _currentHealth;

    public event UnityAction HealthChanged
    {
        add => _healthChanged.AddListener(value);
        remove => _healthChanged.RemoveListener(value);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);
        _healthChanged.Invoke();

        if (_currentHealth == _minHealth)
            _animator.SetBool(IsDiedBool, true);
        else
            _animator.SetTrigger(TakeDamageTrigger);
    }

    public void Heal()
    {
        if (_currentHealth != _maxHealth && _currentHealth != _minHealth)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + _healValue, _minHealth, _maxHealth);
            _animator.SetTrigger(HealTrigger);
            _healthChanged.Invoke();
        }
    }
}

