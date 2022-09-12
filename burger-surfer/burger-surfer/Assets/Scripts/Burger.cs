using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Burger : MonoBehaviour
{
    [SerializeField] private Transform _collector;

    private BoxCollider _boxCollider;
    private bool _isCheeseAdded = false;

    public bool IsCheeseAdded => _isCheeseAdded;

    public BoxCollider BoxCollider => _boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OffCollider()
    {
        BoxCollider.enabled = false;
    }

    public void AddIngredient(GameObject ingredient)
    {
        _isCheeseAdded = true;
        GameObject newIngredient = Instantiate(ingredient, _collector.position, _collector.rotation);
        newIngredient.transform.SetParent(transform);
    }
}

enum Ingredients
{
    Cheese,
    Bacon,
    Beef,
}
