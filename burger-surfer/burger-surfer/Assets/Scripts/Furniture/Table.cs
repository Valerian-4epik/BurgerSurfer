
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Stickman _lastStickman;
    [SerializeField] private List<Stickman> _stickmans;

    private BurgerCollector _player;

    public BurgerCollector Player { set { _player = value; } }

    private void OnTriggerExit(Collider other)
    {
      if(other.TryGetComponent(out BurgerCollector player))
        {
            DisableEverything();
        }  
    }

    private void OnEnable()
    {
        _lastStickman.OnGetBurger += ActiveMovment;
    }

    private void OnDisable()
    {
        _lastStickman.OnGetBurger -= ActiveMovment;
    }

    private void ActiveMovment()
    {
        _player.gameObject.GetComponent<PlayerMover>().CanInteract = true;
    }

    private void DisableEverything()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;

        foreach(Stickman stickman in _stickmans)
        {
            stickman.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
