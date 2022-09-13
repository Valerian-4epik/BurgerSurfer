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

    public bool IsIngredientAdded { get { return _isIngredientAdded; } set { _isIngredientAdded = value; } }
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
        _isIngredientAdded = true;
        GameObject newIngredient = Instantiate(ingredient, _collector.position, _collector.rotation);
        newIngredient.transform.SetParent(transform);
        float _collectedIngredientSizeY = newIngredient.GetComponent<BoxCollider>().bounds.size.y;
        _topBun.transform.position = _topBun.transform.position + new Vector3(0, _collectedIngredientSizeY, 0); 
        Debug.Log(_collectedIngredientSizeY);
    }

    public void ActivateRigids()
    {
        foreach(Rigidbody rigidbody in _bodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}

enum Ingredients
{
    Cheese,
    Bacon,
    Beef,
}
