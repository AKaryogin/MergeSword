using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Money _money;

    private void OnEnable()
    {
        _moneyText.text = _money.GetMoney.ToString();
        _money.Added += OnAdded;        
    }

    private void OnDisable()
    {
        _money.Added -= OnAdded;       
    }

    private void OnAdded(int value)
    {
        _moneyText.text = value.ToString();
    }
}
