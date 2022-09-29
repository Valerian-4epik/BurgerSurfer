using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private List<Customer> _customers;
    [SerializeField] private Transform _checkpoint;

    private Camera _camera;
    private Canvas _mainCanvas;
    private MoneyInfo _playerMoney;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMover player))
        {
            player.StopMovement();
            ActiveCustomers();
            _mainCanvas.gameObject.GetComponent<MainCanvas>().ActiveButton();
            player.CheckPointPosition = _checkpoint;
        }
    }

    public void GetCamera(Camera camera)
    {
        _camera = camera;
    }
    
    public void GetCanvas(Canvas canvas)
    {
        _mainCanvas = canvas;
    }

    public void GetMoneyInfo(MoneyInfo playerMoney)
    {
        _playerMoney = playerMoney;
    }

    private void ActiveCustomers()
    {
        foreach (Customer customer in _customers)
        {
            customer.gameObject.SetActive(true);
            customer.GetMoneyInfo(_playerMoney);
        }
    }

    private void SetFinishPosition()
    {
        // _camera.gameObject.transform.rotation = Vector3.Lerp(gameObject.transform.rotation,
        //     transform.rotation + new Vector3(30, 0, 0), 2 * Time.deltaTime);
    }
}