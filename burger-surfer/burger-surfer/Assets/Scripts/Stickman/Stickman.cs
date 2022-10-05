using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] private ParticleSystem _money;
    
    public Vector3 _burgerPoint
    {
        get { return _money.gameObject.transform.position; }
    }
    
    public void GetBurger()
    {
        ExplosionMoney();
        gameObject.GetComponent<Animation>().Play();
    }
    
    private void ExplosionMoney()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        _money.Play();
    }
}
