using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Foods
{
    public enum IngredientInfo
    {
        Cheese = 5,
        Tomato = 4,
        Onion = 1,
        Bacon = 7,
        Beef = 8,
        Cucumber = 3,
        Egg = 6,
        Lettuce = 2,
    }

    public class Ingredient : MonoBehaviour
    {
        [FormerlySerializedAs("_nameAndPrice")] [SerializeField] private IngredientInfo _infoAndPrice;

        public int Price { get; private set; }

        public Ingredient(IngredientInfo ingredientInfo)
        {
            Price = (int)ingredientInfo;
            ingredientInfo.ToString();
        }
    
        private void Awake()
        {
            Price = (int)_infoAndPrice;
            _infoAndPrice.ToString();
        }
    }
}