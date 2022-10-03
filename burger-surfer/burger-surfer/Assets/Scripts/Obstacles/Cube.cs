using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Transform _burgerPoint;
    
    private bool _isStorageFull = false;

    public Transform BurgerPoint => _burgerPoint;
    
    public bool IsBurgerFull { get { return _isStorageFull; } set { _isStorageFull = value; } }
}
