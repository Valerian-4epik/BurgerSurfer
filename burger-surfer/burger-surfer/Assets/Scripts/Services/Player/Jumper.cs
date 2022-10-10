using Scripts.Furnitures;
using UnityEngine;

namespace Scripts.Services.PlayerJumper
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private BoxCollider _boxCollider;
        [SerializeField] private Table _table;

        private void OnTriggerEnter(Collider other)
        {
            float height = _boxCollider.bounds.size.y;

            if (other.gameObject.TryGetComponent(out BurgerCollector player))
            {
                player.gameObject.transform.position += new Vector3(0, height, 0);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
