using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _numberOfCoins;

    public void AddCoin()
    {
        _numberOfCoins++;
        Debug.Log($"Сейчас в кошельке {_numberOfCoins} яблок");
    }
}
