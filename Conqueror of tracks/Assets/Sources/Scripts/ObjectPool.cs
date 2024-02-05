using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool = new List<GameObject>();
    private int _currentIndexPool = 0;

    protected void Initialize(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        spawned.SetActive(false);
        _pool.Add(spawned);
    }

    protected bool TryGetFirstObject(out GameObject result)
    {
        result = _pool.Skip(_currentIndexPool).FirstOrDefault(p => !p.activeSelf);
        _currentIndexPool++;

        return result != null;
    }
}
