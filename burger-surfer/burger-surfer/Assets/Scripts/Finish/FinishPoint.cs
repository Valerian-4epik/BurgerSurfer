using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private List<Customer> _customers;
    [SerializeField] private Transform _checkpoint;
    [SerializeField] Camera _camera;
    [SerializeField] Canvas _mainCanvas;
    [SerializeField] MoneyInfo _playerMoney;

    private BurgerCollector _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMover player))
        {
            player.StopMovement();
            ActiveCustomers();
            _mainCanvas.gameObject.GetComponent<MainCanvas>().ActiveButton();
            player.CheckPointPosition = _checkpoint;
            GetFinishCustomers(player.gameObject.GetComponent<BurgerCollector>());
            _player = player.gameObject.GetComponent<BurgerCollector>();
            _player.DisableAllBurgers();
        }
    }

    // public void GetCamera(Camera camera)
    // {
    //     _camera = camera;
    // }
    //
    // public void GetCanvas(Canvas canvas)
    // {
    //     _mainCanvas = canvas;
    // }
    //
    // public void GetMoneyInfo(MoneyInfo playerMoney)
    // {
    //     _playerMoney = playerMoney;
    // }

    public void AddCustomer(Customer customer)
    {
        _player.AddFinishCustomers(customer);
    }
    
    private void GetFinishCustomers(BurgerCollector collector)
    {
        foreach (Customer customer in _customers)
        {
            if (customer.IsBought)
                collector.AddFinishCustomers(customer);
        }
    }

    private void ActiveCustomers()
    {
        foreach (Customer customer in _customers)
        {
            if (!customer.IsBought)
            {
                customer.gameObject.SetActive(true);
                customer.GetMoneyInfo(_playerMoney);    
            }
        }
    }

    private void SetFinishPosition()
    {
        // _camera.gameObject.transform.rotation = Vector3.Lerp(gameObject.transform.rotation,
        //     transform.rotation + new Vector3(30, 0, 0), 2 * Time.deltaTime);
    }
}