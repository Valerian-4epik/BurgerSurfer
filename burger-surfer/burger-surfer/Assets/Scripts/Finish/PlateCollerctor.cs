using System.Collections.Generic;
using UnityEngine;

public class PlateCollerctor : MonoBehaviour
{
    [SerializeField] private List<Transform> _burgerPoints = new List<Transform>();

    public List<Transform> BurgerPoints => _burgerPoints;
}
