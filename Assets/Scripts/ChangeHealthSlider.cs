using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthSlider : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Player _player;
    [SerializeField] private float _durationSpeed;

    private void Start()
    {
        _healthSlider.maxValue = _player.MaxHealth;
        _healthSlider.minValue = _player.MinHealth;
        _healthSlider.value = _player.CurrentHealth;
    }

    public void ChangeSlider()
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
