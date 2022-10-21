using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Services.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour
    {
        private const float FinishSpeed = 8;
        private Vector3 LastMousePosition;

        [SerializeField] private float _rightSpeed;
        [SerializeField] private float _sideLerpSpeed;
        [SerializeField] private GameObject _nextLevelPanel;
        [SerializeField] private bool _isPlaying = false;

        private Rigidbody _rigidbody;
        private bool _canInteract = true;

        [FormerlySerializedAs("horizontalAxis")]
        public string _horizontalAxis = "Horizontal";

        private float _inputHorizontal;
        private Vector3 _position;


        public float RightSpeed
        {
            set => _rightSpeed = value;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _inputHorizontal = SimpleInput.GetAxis(_horizontalAxis);
            var mouseDelta = new Vector2((Input.mousePosition.x - LastMousePosition.x) * Time.deltaTime * 0.5f,
                (Input.mousePosition.y - LastMousePosition.y) * Time.deltaTime * 0.5f);
            LastMousePosition = Input.mousePosition;

            if (!_isPlaying) return;
            MoveForward();

            _position = transform.position;

            if (_canInteract)
            {
                _position.z -= mouseDelta.x;
                _position.z = SidewaysDirection(_position.z);
            }

            transform.position = _position;
            // transform.position = new Vector3(transform.position.x,transform.position.y, SidewaysDirection(_inputHorizontal));
        }


        public void MoveToCheckpoint()
        {
            _rightSpeed = FinishSpeed;
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

        private float SidewaysDirection(float positionZ)
        {
            float directionZ = positionZ;
            var maxDistance = 4;
            var minDistance = -4.5F;

            return Mathf.Clamp(directionZ, minDistance, maxDistance);
        }
    }
}