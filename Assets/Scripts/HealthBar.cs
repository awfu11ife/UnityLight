using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Player _player;
    [SerializeField] private float _durationSpeed;

    private void OnEnable()
    {
        _healthSlider.maxValue = _player.MaxHealth;
        _healthSlider.minValue = _player.MinHealth;
        _healthSlider.value = _player.CurrentHealth;

        _player.HealthChanged += ChangeSlider;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeSlider;
    }

    private void ChangeSlider()
    {
        StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        while(_healthSlider.value != _player.CurrentHealth)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, _player.CurrentHealth, _durationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
