using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] private ParticleSystem _money;
    
    public void GetBurger()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        _money.Play();
    }
}
