using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientNames
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
    [SerializeField] private IngredientNames _nameAndPrice;

    private int _price;
    private string _name;

    public int Price => _price;
    public string Name => _name;

    public Ingredient(IngredientNames ingredientNames)
    {
        _price = (int)ingredientNames;
        _name = ingredientNames.ToString();
    }

    private void Awake()
    {
        _price = (int)_nameAndPrice;
        _name = _nameAndPrice.ToString();
    }
}
