using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Ingredient _ingredient;

    public Ingredient Ingredient => _ingredient;
}
