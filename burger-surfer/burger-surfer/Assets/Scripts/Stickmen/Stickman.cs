using UnityEngine;

namespace Scripts.Stickmen
{
    public class Stickman : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _money;
    
        public Vector3 BurgerPoint => _money.gameObject.transform.position;

        public void GetBurger()
        {
            ExplosionMoney();
            gameObject.GetComponent<Animation>().Play();
        }
    
        private void ExplosionMoney()
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            _money.Play();
        }
    }
}
    