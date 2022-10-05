using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _rightSpeed;
    [SerializeField] private float _sideLerpSpeed;
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private bool _isPlaying = false;

    private Rigidbody _rigidbody;
    private bool _canInteract = true;
    private Transform _checkPointPosition;
    private float _finishSpeed = 8;

    public float RightSpeed
    {
        get { return _rightSpeed; }
        set { _rightSpeed = value; }
    }

    public Transform CheckPointPosition
    {
        set { _checkPointPosition = value;  }
    }
    
    public bool CanInteract { get { return _canInteract; } set { _canInteract = value; } }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isPlaying)
        {
            MoveForward();

            if (Input.GetMouseButton(0))
            {
                if (_canInteract)
                    MoveSideways();
            }
        }       
    }
    
    public void MoveToCheckpoint()
    {
        _rightSpeed = _finishSpeed;
        ActiveMovement();
    }
    
    public void ActiveMovement()
    {
        _isPlaying = true;
        _rigidbody.isKinematic = false;
    }

    public void StopMovement()
    {
        _isPlaying = false;
        _canInteract = false;
        _rigidbody.isKinematic = true;
    }

    private void MoveForward()
    {
        _rigidbody.velocity = Vector3.right * _rightSpeed;
    }

    private IEnumerator ActiveNextButton (float duration)
    {
        yield return new WaitForSeconds(duration);
        _nextLevelPanel.SetActive(true);
    }

    private void MoveSideways()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            var position = transform.position;
            
            position = Vector3.Lerp(position, new Vector3(position.x, position.y, hit.point.z),
                _sideLerpSpeed * Time.deltaTime);
            transform.position = position;
        }
    }
}
