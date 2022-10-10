using Scripts.Foods;
using UnityEngine;

namespace Scripts.Gates
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private Ingredient _ingredient;

        public Ingredient Ingredient => _ingredient;
    }
}
