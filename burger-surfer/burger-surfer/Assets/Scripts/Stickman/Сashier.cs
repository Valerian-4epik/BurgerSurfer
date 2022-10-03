using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Сashier : MonoBehaviour
{
    [SerializeField] private PlateCollerctor _plateCollerctor;
    [SerializeField] private ParticleSystem _explosionConfitti;
    [SerializeField] private GameObject _nextLevelPanel;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BurgerCollector player))
        {
            player.gameObject.GetComponent<PlayerMover>().StopMovement();
            _nextLevelPanel.SetActive(true);
            _explosionConfitti.Play();
            StartCoroutine(HandOutExtraBurgers(player));
        }
    }

    private IEnumerator HandOutExtraBurgers(BurgerCollector player)
    {
        for (int i = 0; i < player.Burgers.Count; i++)
        {
            Burger firstBurger = player.Burgers[i];
            firstBurger.DisableRigids();
            firstBurger.transform.DOMove(_plateCollerctor.BurgerPoints[i].transform.position, 1f);
            //player.GiveBurger(_plateCollerctor.BurgerPoints[i]);    
            yield return new WaitForSeconds(0.3f);
        }
    }
}
