using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Burger : MonoBehaviour
{
    [SerializeField] private Transform _collector;
    [SerializeField] private GameObject _topBun;
    [SerializeField] private List<Rigidbody> _bodies = new List<Rigidbody>();

    private BoxCollider _boxCollider;
    private bool _isIngredientAdded = false;
    private List<Ingredient> _ingredients = new List<Ingredient>();

    public bool IsIngredientAdded { get { return _isIngredientAdded; } set { _isIngredientAdded = value; } }
    public BoxCollider BoxCollider => _boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        Ingredient startIngredient = new Ingredient(IngredientNames.Beef);
        _boxCollider = GetComponent<BoxCollider>();
        _ingredients.Add(startIngredient);
        Debug.Log(_ingredients.Count);
        Debug.Log(_ingredients[0].Price);
        Debug.Log(_ingredients[0].Name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int BurgerPrice()
    {
        int price = 0;

        foreach(Ingredient ingredient in _ingredients)
        {
            price += ingredient.Price;
        }

        return price;
    }

    public void OffCollider()
    {
        BoxCollider.enabled = false;
    }

    public void AddIngredient(GameObject ingredient)
    {
        _isIngredientAdded = true;
        GameObject newIngredient = Instantiate(ingredient, _collector.position, _collector.rotation);
        newIngredient.transform.SetParent(transform);
        float _collectedIngredientSizeY = newIngredient.GetComponent<BoxCollider>().bounds.size.y;
        _topBun.transform.position = _topBun.transform.position + new Vector3(0, _collectedIngredientSizeY, 0);
        _ingredients.Add(ingredient.GetComponent<Ingredient>());
      
        //Debug.Log(_collectedIngredientSizeY);
    }

    public void ActivateRigids()
    {
        foreach(Rigidbody rigidbody in _bodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}

