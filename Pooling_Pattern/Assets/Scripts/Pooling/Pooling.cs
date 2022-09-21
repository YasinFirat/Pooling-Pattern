using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Here Objects are placed in the pool and recalled for use.
/// PoolMember script is added to each Pool member.
/// Set active of each member in the pool is false
/// Set active of each member leaving the pool is true. 
/// </summary>
[System.Serializable]
public class Pooling:IPoolable
{

    public string nameOfPool= "You can write a name.";
    public PoolFeatures features;
    private GameObject[] pool;
    private PoolObject poolObject=new PoolObject();
    /// <summary>
    /// Objects are filled into the Pool and the PoolMember script is added to become a member of the Pool.
    /// </summary> 
    public void FillPool()
    {
        GameObject newObject = new GameObject();
        pool = new GameObject[features.totalMember];
        for (int i = 0; i < features.totalMember; i++)
        {
            newObject = Object.Instantiate(features.prefab, features.parent);
            newObject.SetActive(false);
            newObject.AddComponent<PoolMember>().SetPoolNames(features.POOLNAMES);
            pool[i] = newObject;
        }
    }
    public GameObject PullFromPool()
    {
        return FindFromPool()?.getPoolObject;
    }
    public GameObject PullFromPool(Vector3 _position)
    {
        return FindFromPool()?.SetPosition(_position).getPoolObject;
    }
    public GameObject PullFromPool(Vector3 _position, Quaternion _rotation)
    {
        return FindFromPool()?.SetPosition(_position).SetRotation(_rotation).getPoolObject;
    }
    public void AddPool(GameObject gameObject)
    {
        if (gameObject.transform.parent != features.parent)
        {
            gameObject.transform.SetParent(features.parent);
        }
        gameObject.SetActive(false);
    }
    private PoolObject FindFromPool()
    {
        for (int i = 0; i < features.totalMember; i++)
        {
            poolObject.SetPoolObject(pool[i]);
            if (!poolObject.isActive)
            {
                return poolObject;
            }
        }
        return null;
    }
}
