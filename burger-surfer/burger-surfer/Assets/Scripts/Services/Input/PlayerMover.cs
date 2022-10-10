using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.ProBuilder;

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
    public string horizontalAxis = "Horizontal";
    private float inputHorizontal;

    
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
        inputHorizontal =  SimpleInput.GetAxis(horizontalAxis);
        
        if (_isPlaying)
        {
            MoveForward();

            if (_canInteract) 
                transform.position = new Vector3(transform.position.x,transform.position.y, SidewaysDirection(inputHorizontal));
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

    private float SidewaysDirection(float inputAxis)
    {
        float directionZ = transform.position.z;
        var maxDistance = 4;
        var minDistance = -4.5F;

        return Mathf.Clamp(directionZ - inputAxis * _sideLerpSpeed, minDistance, maxDistance);
    }
    
    private void MoveSideways(float direction)
    {
        var position = transform.position;
            
            position = Vector3.Lerp(position, new Vector3(position.x, position.y, -direction * _sideLerpSpeed),
                _sideLerpSpeed * Time.deltaTime);
            transform.position = position;
        
    }
}
