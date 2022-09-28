using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    [SerializeField] private List<GameObject> _customers;

    private Camera _camera;
    private Canvas _mainCanvas;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMover player))
        {
            player.StopMovement();
            ActiveCustomers();
        }
    }

    public void GetCamera(Camera camera)
    {
        _camera = camera;
    }

    private void ActiveCustomers()
    {
        foreach (GameObject customer in _customers)
        {
            customer.SetActive(true);
        }
    }

    private void SetFinishPosition()
    {
        // _camera.gameObject.transform.rotation = Vector3.Lerp(gameObject.transform.rotation,
        //     transform.rotation + new Vector3(30, 0, 0), 2 * Time.deltaTime);
    }
}