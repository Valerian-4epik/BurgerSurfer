using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Burger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ingredients;

    private BoxCollider _boxCollider;

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
        _ingredients.Add(ingredient);
    }
}

enum Ingredients
{
    Cheese,
    Bacon,
    Beef,
}
