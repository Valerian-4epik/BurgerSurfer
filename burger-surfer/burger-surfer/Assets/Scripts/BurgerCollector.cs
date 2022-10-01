using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class BurgerCollector : MonoBehaviour
{
    [SerializeField] private Transform _collector;
    [SerializeField] private float _duration;
    [SerializeField] private Rigidbody _burgerSurfer;

    private float _collectedBurgerSizeY;
    private float _burgerTravelTime = 0.5f;
    private List<Burger> _burgers = new List<Burger>();
    private List<Customer> _finishCustomers = new List<Customer>();

    public List<Burger> Burgers => _burgers;
    public Action<int> OnSellBurger;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Burger burger))
        {
            //burger.PlayScaleUpAnimation();
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
                OnSellBurger.Invoke(_burgers[_burgers.Count - 1].BurgerPrice());
                GiveBurger(stickman.transform);
                stickman.GetBurger();
            }
            else
            {
                
            }
        }
        else if (other.gameObject.TryGetComponent(out Cube cube))
        {
            if (!cube.IsBurgerFull)
            {
                GiveBurger(cube.transform);
                cube.gameObject.GetComponent<BoxCollider>().enabled = false;
                cube.IsBurgerFull = true;
            }
        }
    }

    public void AddFinishCustomers(Customer customer)
    {
        _finishCustomers.Add(customer);
    }

    private void Take(Burger burger)
    {
        _burgers.Add(burger);
        UpgradeCapability();
        burger.transform.SetParent(transform);
        _collectedBurgerSizeY = burger.BoxCollider.bounds.size.y;
        transform.position = transform.position + new Vector3(0, _collectedBurgerSizeY, 0);
        _collector.position = _collector.position - new Vector3(0, _collectedBurgerSizeY, 0);
        burger.OffCollider();
        MoveBlock(burger);
        burger.ActivateRigids();
    }

    public void GiveBurger(Transform transform)
    {
        if (_burgers.Count > 1)
        {
            GameObject lastBurger = _burgers[_burgers.Count - 1].gameObject;
            lastBurger.transform.SetParent(transform);
            _burgers.Remove(_burgers[_burgers.Count - 1]);
            //_burgerSurfer.isKinematic = false;
        }
    }

    public void FeedAllFinishCustomers()
    {
        if (_finishCustomers.Count > 0)
        {
            foreach (Customer customer in _finishCustomers)
            {
                GameObject lastBurger = _burgers[_burgers.Count - 1].gameObject;
                OnSellBurger.Invoke(lastBurger.GetComponent<Burger>().BurgerPrice());
                //lastBurger.GetComponent<Burger>().DisableRigids();
                lastBurger.transform.DOMove(customer.TargetPosition.position, _burgerTravelTime);
                GiveBurger(customer.gameObject.transform);
            }
        }
    }

    public void DisableAllBurgers()
    {
        foreach (Burger burger in _burgers)
        {
            burger.DisableRigids();
        }
    }

    public int BurgersPrice()
    {
        int sum = 0;

        foreach(Burger burger in _burgers)
        {
            sum += burger.BurgerPrice();
        }

        return sum;
    }

    private void MoveBlock(Burger burger)
    {
        //burger.transform.DOLocalRotate(_targetRotation, _duration);
        burger.transform.DOLocalMove(_collector.transform.localPosition, _duration);
        
    }

    private void UpgradeCapability()
    {
        foreach (Burger burger in _burgers)
        {
            burger.IsIngredientAdded = false;
        }
    }

    private void MoveToCentrePosition()
    {
        Vector3 surferPosition = gameObject.transform.position;
        //Vector3 задать силу по направлению
        gameObject.transform.position = new Vector3(surferPosition.x, surferPosition.y, 0);
        gameObject.GetComponent<PlayerMover>().CanInteract = true;
    }
}
