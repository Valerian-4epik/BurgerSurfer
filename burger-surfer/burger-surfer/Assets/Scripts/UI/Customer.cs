using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _table;
    [SerializeField] private Button _button;
    [SerializeField] private Transform _targerPosition;
    [SerializeField] private FinishPoint _finishPoint;
    
    private MoneyInfo _playerMoney;
    private bool _isBought;

    public Transform TargetPosition => _targerPosition;

    public bool IsBought => _isBought;
    
    private void Start()
    {
        if (_isBought)
        {
            ActivateTable();  
        }
        
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
            _isBought = true;
            _finishPoint.AddCustomer(this);
            ActivateTable();
        }
    }

    private void ActivateTable()
    {
        _table.SetActive(true);
        gameObject.GetComponent<Image>().enabled = false;
        _button.gameObject.SetActive(false);
    }
}
