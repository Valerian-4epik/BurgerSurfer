using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class MoneyInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyView;
    [SerializeField] private BurgerCollector _player;

    int _playerMoney;

    private void OnEnable()
    {
        _player.OnSellBurger += AddMoney;
    }

    private void OnDisable()
    {
        _player.OnSellBurger -= AddMoney;
    }

    private void Awake()
    {
        _playerMoney = SaveProgress.MoneyBalance;
    }

    void Start()
    {
        ShowMoney();
    }

    public void SpendMoney(int value, out bool successful)
    {
        successful = IsEnoughMoney(value);
        
        if (IsEnoughMoney(value))
            _playerMoney -= value;
        
        ShowMoney();
        SaveProgress.MoneyBalance = _playerMoney;
    }

    public bool IsEnoughMoney(int value)
    {
        return _playerMoney >= value;
    }

    private void AddMoney(int value)
    {
        _playerMoney += value; 
        ShowMoney();
        SaveProgress.MoneyBalance = _playerMoney;
    }

    private void ShowMoney()
    {
        _moneyView.text = _playerMoney.ToString();
    }
}
