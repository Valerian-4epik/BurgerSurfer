using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BurgerCollector : MonoBehaviour
{
    [SerializeField] private Transform _collector;
    [SerializeField] private float _duration;
    [SerializeField] private Rigidbody _burgerSurfer;

    private float _collectedBurgerSizeY;
    private List<Burger> _burgers = new List<Burger>();

    public Action<int> OnSellBurger;

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

    private void Take(Burger burger)
    {
        _burgers.Add(burger);
        UpgradeCapability();
        burger.transform.SetParent(transform);
        _collectedBurgerSizeY = burger.BoxCollider.bounds.size.y;
        transform.position = transform.position + new Vector3(0, _collectedBurgerSizeY, 0);
        _collector.position = _collector.position - new Vector3(0, _collectedBurgerSizeY, 0);
        //transform.position = new Vector3(transform.position.x, transform.position.y + _collectedBurgerSizeY, transform.position.z);
        //Jump?.Invoke(_collectedBlockSizeY);
        burger.OffCollider();
        //block.ChangeMaterial(_collectedBlockMaterial);
        MoveBlock(burger);
        burger.ActivateRigids();
    }

    private void GiveBurger(Transform transform)
    {
        if (_burgers.Count > 1)
        {
            GameObject lastBurger = _burgers[_burgers.Count - 1].gameObject;
            lastBurger.transform.SetParent(transform);
            //stop
            _burgers.Remove(_burgers[_burgers.Count - 1]);
            //_burgerSurfer.isKinematic = false;
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
