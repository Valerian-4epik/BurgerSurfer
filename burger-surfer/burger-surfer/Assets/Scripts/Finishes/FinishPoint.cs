using System.Collections.Generic;
using DG.Tweening;
using Scripts.Services;
using Scripts.Services.Player;
using Scripts.Services.PlayerStats;
using Scripts.UI;
using UnityEngine;

namespace Scripts.Finishes
{
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
            SetupFinishSettings(other);
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
        
        private void SetupFinishSettings(Collider other)
        {
            if (other.TryGetComponent(out PlayerMover player))
            {
                player.StopMovement();
                ActivateCustomers();
                _mainCanvas.gameObject.GetComponent<MainCanvas>().ActiveButton();
                AddFinishCustomers(player.gameObject.GetComponent<BurgerCollector>());
                _player = player.gameObject.GetComponent<BurgerCollector>();
                player.gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
                SetCamera();
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    
        private void AddFinishCustomers(BurgerCollector collector)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.IsBought)
                    collector.AddFinishCustomers(customer);
            }
        }

        private void ActivateCustomers()
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

        private void SetCamera()
        {
            _camera.gameObject.GetComponent<CameraFollower>().IsFinishPositionActive = true;
            var endValue = new Vector3(46,  90, 0);
            var duration = 2;
            _camera.transform.DORotate(endValue, duration);
        }
    }
}
