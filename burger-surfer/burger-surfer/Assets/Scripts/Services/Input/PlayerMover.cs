using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _rightSpeed;
    [SerializeField] private float _sideLerpSpeed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveForward();

        if (Input.GetMouseButton(0))
        {
            MoveSideways();
        }
    }

    private void MoveForward()
    {
        _rigidbody.velocity = Vector3.right * _rightSpeed;
    }

    private void MoveSideways()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, hit.point.z),
                _sideLerpSpeed * Time.deltaTime);
        }
    }
}
