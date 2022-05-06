using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private float _changeDuration;
    [SerializeField] private int _healValue;

    private int _minHealth = 0;
    private Tweener _sliderAnimation;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.minValue = _minHealth;
        _healthSlider.value = _currentHealth;
        _sliderAnimation = _healthSlider.DOValue((float)_currentHealth, _changeDuration).SetAutoKill(false);
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealth - damage > _minHealth)
        {
            _currentHealth -= damage;
            _animator.SetTrigger("TakeDamage");
            _sliderAnimation.ChangeEndValue((float)_currentHealth, true).Restart();
        }
        else
        {
            _currentHealth = _minHealth;
            _sliderAnimation.ChangeEndValue((float)_currentHealth, true).Restart();
        }

        if (_currentHealth == _minHealth)
            _animator.SetBool("IsDied", true);
    }

    public void Heal()
    {
        if (_currentHealth != _maxHealth && _currentHealth != _minHealth)
        {
            if (_currentHealth + _healValue <= _maxHealth)
            {
                _currentHealth += _healValue;
                _animator.SetTrigger("Heal");
                _sliderAnimation.ChangeEndValue((float)_currentHealth, true).Restart();
            }
            else
            {
                _currentHealth = _maxHealth;
                _animator.SetTrigger("Heal");
                _sliderAnimation.ChangeEndValue((float)_currentHealth, true).Restart();
            }
        }
    }
}

