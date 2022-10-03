using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTable : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _explosionMoney;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out TopBun topBun))
        {
            foreach (ParticleSystem explosion in _explosionMoney)
            {
                explosion.Play();
            }
        }
    }
}
