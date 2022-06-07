using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    [SerializeField] private int _numberOfBullets;

    [Range(1f, 40f)]
    [SerializeField] private float _bulletScatter;

    private float _firstBulletDegree;
    private float _degreeBetweenBullets;
    private float _lastAttackTime;

    public override void Shoot(Transform shootPoint)
    {
        if (_lastAttackTime <= 0)
        {
            CalculateBulletPosition();

            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < _numberOfBullets; i++)
                {
                    Instantiate(Bullet, shootPoint.position, Quaternion.Euler(0, 0, _firstBulletDegree));
                    _firstBulletDegree += _degreeBetweenBullets;
                }

                _lastAttackTime = Delay;
            }
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void CalculateBulletPosition()
    {
        _firstBulletDegree = -(_bulletScatter / 2);
        _degreeBetweenBullets = _bulletScatter / _numberOfBullets;
    }
}