
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private BurgerCollector _player;
    private float _tableSpeed = 14f;

    public BurgerCollector Player { set { _player = value; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMover player))
            player.RightSpeed = _tableSpeed;
        // if (other.TryGetComponent(out PlayerMover player))
        //     player.CanInteract = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMover player))
            player.RightSpeed = 12f; //магическое число;
        
        // if (other.TryGetComponent(out PlayerMover player))
        //     player.CanInteract = true;
    }
}
