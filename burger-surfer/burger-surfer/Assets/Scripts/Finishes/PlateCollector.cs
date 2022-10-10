using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Finishes
{
    public class PlateCollector : MonoBehaviour
    {
        [SerializeField] private List<Transform> _burgerPoints = new();

        public List<Transform> BurgerPoints => _burgerPoints;
    }
}
