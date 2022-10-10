using Scripts.Services.Player;
using UnityEngine;

namespace Scripts.Furnitures
{
    public class Table : MonoBehaviour
    {
        private const float TableSpeed = 14f;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMover player))
                player.RightSpeed = TableSpeed;
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMover player))
            {
                var componentRightSpeed = 12f;
                player.RightSpeed = componentRightSpeed;
            }
        }
    }
}
