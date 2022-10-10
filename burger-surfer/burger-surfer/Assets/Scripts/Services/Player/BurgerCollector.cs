using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Scripts.Foods;
using Scripts.Gates;
using Scripts.Obstacles;
using Scripts.Stickmen;
using Scripts.UI;
using UnityEngine;

namespace Scripts
{
    public class BurgerCollector : MonoBehaviour
    {
        private const float BurgerTravelTime = 1f;
        
        [SerializeField] private Transform _collector;
        [SerializeField] private float _duration;
        [SerializeField] private Rigidbody _burgerSurfer;
        [SerializeField] private Transform _parentTransform;

        private float _collectedBurgerSizeY;
        private readonly List<Customer> _finishCustomers = new();
        private readonly List<Burger> _burgers  = new();

        public Action<int> OnSellBurger;
        
        public int BurgerCount => _burgers.Count;
    
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Burger burger))
            {
                Take(burger);
            }
            else if (other.gameObject.TryGetComponent(out Gate gate))
            {
                foreach (Burger sandwich in _burgers)
                {
                    if (!sandwich.IsIngredientAdded)
                        sandwich.AddIngredient(gate.Ingredient);
                }
            }
            else if (other.gameObject.TryGetComponent(out Stickman stickman))
            {
                if (_burgers.Count > 1)
                {
                    SellBurger(stickman);
                }
            }
            else if (other.gameObject.TryGetComponent(out Cube cube))
            {
                cube.gameObject.GetComponent<BoxCollider>().enabled = false;
            
                if (!cube.IsStorageFull)
                {
                    cube.IsStorageFull = true;
                    GiveBurger(_parentTransform);
                }   
            }
        }



        public Burger GetBurger(int number)
        {
            return _burgers[number];
        }
        
        public void AddFinishCustomers(Customer customer)
        {
            _finishCustomers.Add(customer);
        }
        
        private void SellBurger(Stickman stickman)
        {
            var lastBurger = _burgers[^1];
            OnSellBurger.Invoke(lastBurger.BurgerPrice());
            GiveBurger(_parentTransform);
            const float duration = 0.1f;
            lastBurger.gameObject.transform.DOMove(stickman.BurgerPoint, duration);
            stickman.GetBurger();
        }

        private void Take(Burger burger)
        {
            _burgers.Add(burger);
            UpgradeCapability();
            burger.transform.SetParent(transform, true);
            burger.PlayScaleUpAnimation();
            _collectedBurgerSizeY = burger.BoxCollider.bounds.size.y;
            transform.position += new Vector3(0, _collectedBurgerSizeY, 0);
            _collector.position -= new Vector3(0, _collectedBurgerSizeY, 0);
            burger.DisableCollider();
            MoveBlock(burger);
            burger.ActivateRigids();
        }

        private void GiveBurger(Transform transform)
        {
            if (_burgers.Count > 0)
            {
                GameObject lastBurger = _burgers[^1].gameObject;
                lastBurger.transform.SetParent(transform, true);
                _burgers.Remove(_burgers[^1]);
            }
        }

        public void FeedAllFinishCustomers()
        {
            StartCoroutine(DistributionFinishBurgers());
        }
        
        public int BurgersPrice()
        {
            int sum = 0;

            foreach (Burger burger in _burgers)
            {
                sum += burger.BurgerPrice();
            }

            return sum;
        }
    
        private void MoveBlock(Burger burger)
        { 
            burger.transform.DOLocalMove(_collector.transform.localPosition, _duration);
        }

        private void UpgradeCapability()
        {
            foreach (Burger burger in _burgers)
            {
                burger.IsIngredientAdded = false;
            }
        }
        
        private IEnumerator DistributionFinishBurgers()
        {
            foreach (Customer customer in _finishCustomers)
            {
                if (_burgers.Count > 0)
                {
                    Burger lastBurger = _burgers[^1];
                    OnSellBurger.Invoke(lastBurger.BurgerPrice());
                    lastBurger.DisableRigids();
                    lastBurger.transform.DOMove(customer.TargetPosition.position, BurgerTravelTime);
                    GiveBurger(customer.gameObject.transform);
                }

                var distributionFinishBurgers = new WaitForSeconds(0.5f);
                yield return distributionFinishBurgers;
            }
        }
    }
}
