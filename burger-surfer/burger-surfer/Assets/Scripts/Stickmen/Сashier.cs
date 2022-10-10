using System.Collections;
using DG.Tweening;
using Scripts.Finishes;
using Scripts.Foods;
using Scripts.Services.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Stickmen
{
    public class Сashier : MonoBehaviour
    {
        [FormerlySerializedAs("_plateCollector")] [SerializeField] private PlateCollector _plateCollector;
        [SerializeField] private ParticleSystem _explosionConfitti;
        [SerializeField] private GameObject _nextLevelPanel;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BurgerCollector player))
            {
                player.gameObject.GetComponent<PlayerMover>().StopMovement();
                _nextLevelPanel.SetActive(true);
                _explosionConfitti.Play();
                StartCoroutine(HandOutExtraBurgers(player));
            }
        }

        private IEnumerator HandOutExtraBurgers(BurgerCollector player)
        {
            for (int i = 0; i < player.BurgerCount; i++)
            {
                Burger firstBurger = player.GetBurger(i);
                firstBurger.DisableRigids();
                firstBurger.transform.DOMove(_plateCollector.BurgerPoints[i].transform.position, 1f);

                var handOutExtraBurgers = new WaitForSeconds(0.3f);
                yield return handOutExtraBurgers;
            }
        }
    }
}
