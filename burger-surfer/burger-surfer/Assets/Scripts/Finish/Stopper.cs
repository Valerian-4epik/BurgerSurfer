using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMover player))
        {
            player.StopMovement();
            Debug.Log("Есть косание");
        }
    }
}
