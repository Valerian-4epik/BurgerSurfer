using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Foods
{
    [RequireComponent(typeof(BoxCollider))]
    public class Burger : MonoBehaviour
    {
        [SerializeField] private Transform _collector;
        [SerializeField] private GameObject _topBun;
        [SerializeField] private List<Rigidbody> _bodies = new();
        [SerializeField] private Animation _animation;

        private readonly List<Ingredient> _ingredients = new();

        public bool IsIngredientAdded { get; set; }
        public BoxCollider BoxCollider { get; private set; }

        private void Start()
        {
            var startIngredient = new Ingredient(IngredientInfo.Beef);
            BoxCollider = GetComponent<BoxCollider>();
            _ingredients.Add(startIngredient);        
        }
        
        public int BurgerPrice()
        {
            int price = 0;

            foreach(var ingredient in _ingredients)
            {
                price += ingredient.Price;
            }

            return price;
        }

        public void DisableCollider()
        {
            BoxCollider.enabled = false;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            IsIngredientAdded = true;
            GameObject newIngredient = Instantiate(ingredient.gameObject, _collector.position, _collector.rotation);
            newIngredient.GetComponent<Animation>().Play();
            newIngredient.transform.SetParent(transform);
            float _collectedIngredientSizeY = newIngredient.GetComponent<BoxCollider>().bounds.size.y;
            _topBun.transform.position = _topBun.transform.position + new Vector3(0, _collectedIngredientSizeY, 0);
            _ingredients.Add(newIngredient.GetComponent<Ingredient>());
            _bodies.Add(newIngredient.GetComponent<Rigidbody>()); 
        }
    
        public void PlayScaleUpAnimation()
        {
            _animation.Play();
        }

        public void ActivateRigids()
        {
            foreach(Rigidbody rigidbody in _bodies)
            {
                rigidbody.isKinematic = false;
            }
        }

        public void DisableRigids()
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        
            foreach(Rigidbody rigidbody in _bodies)
            {
                rigidbody.isKinematic = true;
            }
        }
    }
}
