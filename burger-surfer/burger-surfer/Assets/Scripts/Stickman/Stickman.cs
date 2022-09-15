using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    private bool _isBurgerEnough = false;

    public Action OnGetBurger;

    public void GetBurger()
    {
        _isBurgerEnough = true;
        OnGetBurger.Invoke();
    }
}
