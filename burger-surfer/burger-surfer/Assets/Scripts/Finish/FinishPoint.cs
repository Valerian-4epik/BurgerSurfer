using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            player.gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
            SetFinishPosition();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void DisableAllCustomers()
    {
        foreach (Customer customer in _customers)
        {
            if (!customer.IsBought)
            {
                customer.gameObject.SetActive(false);
            }
        }
    }

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
        _camera.gameObject.GetComponent<CameraFollower>().IsActiveFinishPosition = true;
        _camera.transform.DORotate(new Vector3(46,  90, 0), 2);
    }
}
