using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Сashier : MonoBehaviour
{
    [SerializeField] private PlateCollerctor _plateCollerctor;
    [SerializeField] private ParticleSystem _explosionConfitti;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BurgerCollector player))
        {
            _explosionConfitti.Play();
            
            for (int i = 0; i < player.Burgers.Count; i++)
            {
                GameObject firstBurger = player.Burgers[i].gameObject;
                firstBurger.GetComponent<Rigidbody>().isKinematic = true;
                firstBurger.transform.DOMove(_plateCollerctor.BurgerPoints[i].transform.position, 1f);
                //player.GiveBurger(_plateCollerctor.BurgerPoints[i]);    
            }
        }
    }
}
