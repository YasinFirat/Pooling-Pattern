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
    Queue<GameObject> pool = new Queue<GameObject>();

    /// <summary>
    /// Objects are filled into the Pool and the PoolMember script is added to become a member of the Pool.
    /// </summary>    
    public void FillPool()
    {
        for (int i = 0; i < totalMember; i++)
        {
            GameObject newObject = Object.Instantiate(prefab, parent);
            newObject.SetActive(false);
            newObject.AddComponent<PoolMember>().POOLNAMES = POOLNAMES;
            pool.Enqueue(newObject);
        }
    }

    /// <summary>
    /// The object is called up and removed from the pool for use.
    /// </summary>
    /// <param name="_position">object's location</param>
    /// <returns></returns>
    public GameObject PullFromPool(Vector3 _position)
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("Dizi dolu olduğundan istediğiniz objeyi çağıramıyoruz.Ya objelerden birini siliniz yada başlangıçta havuz için obje sayısını arttırın");
            return null;
        }
        GameObject call = pool.Dequeue();
        call.transform.position = _position;
        call.SetActive(true);
        return call;
    }
    /// <summary>
    ///The object is sent back to the pool.
    /// </summary>
    /// <param name="gameObject"></param>
    public void AddPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        pool.Enqueue(gameObject);
    }
}
