using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    [SerializeField] private Transform _collector;
    [SerializeField] private float _duration;

    private float _collectedBurgerSizeY;
    //private Vector3 _targetRotation;

    //public event Action<float> Jump;

    //private void OnEnable()
    //{
    //    _targetRotation = Vector3.zero;
    //    _character.BlockCollected += Take;
    //}

    //private void OnDisable()
    //{
    //    _character.BlockCollected -= Take;
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Burger burger))
        {
            Debug.Log("Косание");
            Take(burger);
        }
    }

    private void Take(Burger burger)
    {
        burger.transform.SetParent(transform);
        _collectedBurgerSizeY = burger.BoxCollider.bounds.size.y;
        transform.position = transform.position + new Vector3(0, _collectedBurgerSizeY,0);
        _collector.position = _collector.position - new Vector3(0, _collectedBurgerSizeY, 0);
        //transform.position = new Vector3(transform.position.x, transform.position.y + _collectedBurgerSizeY, transform.position.z);
        //Jump?.Invoke(_collectedBlockSizeY);
        burger.OffCollider();
        //block.ChangeMaterial(_collectedBlockMaterial);
        MoveBlock(burger);
    }

    private void MoveBlock(Burger burger)
    {  
        //burger.transform.DOLocalRotate(_targetRotation, _duration);
        burger.transform.DOLocalMove(_collector.transform.localPosition, _duration);
    }
}
