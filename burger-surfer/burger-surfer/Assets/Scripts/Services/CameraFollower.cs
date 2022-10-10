using UnityEngine;

namespace Scripts.Services
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smooth;
        [SerializeField] private Vector3 _offset;

        private float _deltaX;
        private bool _isFinishPositionActive;
    
        public bool IsFinishPositionActive
        {
            set => _isFinishPositionActive = value;
        }

        private void Start()
        {
            _deltaX = transform.position.x - _target.position.x;
        }

        private void Update()
        {
            var position = transform.position;
            var targetPosition = new Vector3(position.x, _target.position.y, position.z); 
            position = new Vector3(_target.position.x + _deltaX, position.y, position.z);
            position = Vector3.Lerp(position, targetPosition + _offset, Time.deltaTime * _smooth);
            transform.position = position;

            if (!_isFinishPositionActive) return;
            const int yDistance = 18;
            const int duration = 10;
            SetYOffset(yDistance,duration);
        }

        private void SetYOffset(float yDistance, float duration)
        {
            _offset = Vector3.MoveTowards(_offset, new Vector3(_offset.x, yDistance, _offset.z),
                duration * Time.deltaTime);
        }
    }
}
