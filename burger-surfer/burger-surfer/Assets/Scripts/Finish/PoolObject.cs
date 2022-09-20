using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolObject<T> where T: MonoBehaviour //where - ограничение
{
    private T _prefab;
    private Transform _container;
    private List<T> _pool = new List<T>();
    private int _capacity;

    public PoolObject(T prefab, Transform container, int capacity)
    {
        _prefab = prefab;
        _container = container;
        _capacity = capacity;

        CreatePool();
    }

    public bool TryGetObject<T>(out T result) where T:class //мы получим т где т будет классом
    {
        result = _pool.FirstOrDefault(t => t.gameObject.activeInHierarchy == false) as T;

        if (result == null)
            result = ExpandPool() as T;
        
        return result != null;
    }

    private T ExpandPool()
    {
        T newObject = Object.Instantiate(_prefab, _container);
        newObject.gameObject.SetActive(false);
        _pool.Add(newObject);
        return newObject;
    }

    private void CreatePool()
    {
        for (int i = 0; i < _capacity; i++)
        {
            T newObject = Object.Instantiate(_prefab, _container);
            newObject.gameObject.SetActive(false);
            _pool.Add(newObject);
        }
    }
}