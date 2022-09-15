using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool _isStorageFull = false;

    public bool IsBurgerFull { get { return _isStorageFull; } set { _isStorageFull = value; } }
}
