using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject _ingredient;

    public GameObject Ingredient => _ingredient;
}
