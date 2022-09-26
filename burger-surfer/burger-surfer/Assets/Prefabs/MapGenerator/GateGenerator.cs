using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//using Random = System.Random;

public class GateGenerator : MonoBehaviour
{
    [SerializeField] private List<Gate> _gates = new List<Gate>();

    //private Random _randomGate = new Random();

    private void Start()
    {
        Instantiate(GetRandomGate(), transform.position, Quaternion.identity);
    }

    private Gate GetRandomGate()
    {
        int gateNumber = Random.Range(0, _gates.Count);
        return _gates[gateNumber];
    }
}
