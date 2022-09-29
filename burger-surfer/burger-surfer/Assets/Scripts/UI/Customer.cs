using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _table;

    private Button _button;
    private MoneyInfo _playerMoney;
    
    private void Start()
    {
        _button = gameObject.GetComponentInChildren<Button>();
        _button.onClick.AddListener(BuyCustomer);
        _text.text = _price.ToString();
    }
    
    public void GetMoneyInfo(MoneyInfo moneyInfo)
    {
        _playerMoney = moneyInfo;
    }

    private void BuyCustomer()
    {
        _playerMoney.SpendMoney(_price, out var successful);

        if (successful)
        {
            _table.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
