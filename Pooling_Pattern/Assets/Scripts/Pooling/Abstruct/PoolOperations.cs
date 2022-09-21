using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolOperations : MonoBehaviour,IPoolableWithNames
{

    public Pooling[] poolings;
    /// <summary>
    /// Returns true after all pool objects have been loaded.
    /// </summary>
    public bool isDone { get; private set; }

    public void BackToPool(PoolNames POOLNAMES, GameObject gameObject)
    {
        FindFromPool(POOLNAMES).AddPool(gameObject);
    }
    public GameObject PullFromPool(PoolNames POOLNAMES)
    {
        return FindFromPool(POOLNAMES)?.PullFromPool();
    }
    public GameObject PullFromPool(PoolNames POOLNAMES, Vector3 _position)
    {
        return FindFromPool(POOLNAMES)?.PullFromPool(_position);
    }
    public GameObject PullFromPool(PoolNames POOLNAMES, Vector3 _position, Quaternion _rotation)
    {
        return FindFromPool(POOLNAMES)?.PullFromPool(_position, _rotation);
    }
    public Pooling FindFromPool(PoolNames POOLNAMES)
    {
        for (int i = 0; i < poolings.Length; i++)
        {
            if (poolings[i].features.POOLNAMES == POOLNAMES)
            {
                return poolings[i];
            }
        }
        return null;
    }
    protected void FillPool()
    {
        for (int i = 0; i < poolings.Length; i++)
        {
            poolings[i].FillPool();
        }
        isDone = true;
    }
}
