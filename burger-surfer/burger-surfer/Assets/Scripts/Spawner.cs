using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private cube _cube;
    private PoolObject<cube> _objectPool;

    Transform _container;
    private void Start()
    {
       _objectPool = new PoolObject<cube>(_cube,_container, 5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_objectPool.TryGetObject(out cube cube))
            {
                cube.gameObject.SetActive(true);
            }
        }
    }

}
