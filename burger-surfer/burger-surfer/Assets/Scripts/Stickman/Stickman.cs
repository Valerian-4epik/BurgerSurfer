using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] private ParticleSystem _money;
    
    public void GetBurger()
    {
        ExplosionMoney();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Burger burger))
        {
            ExplosionMoney();
        }
    }

    private void ExplosionMoney()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        _money.Play();
    }
}
