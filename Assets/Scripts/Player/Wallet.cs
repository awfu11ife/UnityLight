using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coinsAmount;

    public void AddCoin()
    {
        _coinsAmount++;
        Debug.Log($"������ � �������� {_coinsAmount} �����");
    }
}
