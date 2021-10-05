using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Here Objects are placed in the pool and recalled for use.
/// PoolMember script is added to each Pool member.
/// Set active of each member in the pool is false
/// Set active of each member leaving the pool is true. 
/// </summary>
[System.Serializable]
public class Pooling
{
    public PoolNames POOLNAMES;
    public GameObject prefab;
    public Transform parent;
    public int totalMember;
    private GameObject[] pool;
    private GameObject newObject;
   
    /// <summary>
    /// Objects are filled into the Pool and the PoolMember script is added to become a member of the Pool.
    /// </summary> 
    public void FillPool()
    {
        pool = new GameObject[totalMember];
        for (int i = 0; i < totalMember; i++)
        {
            newObject = Object.Instantiate(prefab, parent);
            newObject.SetActive(false);
            newObject.AddComponent<PoolMember>().SetPoolNames(POOLNAMES);
            pool[i] = newObject;
        }

      
    }

    /// <summary>
    /// The object is called up and removed from the pool for use.
    /// </summary>
    /// <param name="_position">object's location</param>
    /// <returns></returns>
    public GameObject PullFromPool(Vector3 _position)
    {
        for (int i = 0; i < totalMember; i++)
        {
            newObject = pool[i];
            if (!newObject.activeInHierarchy)
            {
                newObject.SetActive(true);
                return newObject;
            }
        }
        return null;
    }
    /// <summary>
    ///The object is sent back to the pool.
    /// </summary>
    /// <param name="gameObject"></param>
    public void AddPool(GameObject gameObject)
    {
        if (gameObject.transform.parent != parent)
        {
            gameObject.transform.SetParent(parent);
        }
        gameObject.SetActive(false);
    }
}
