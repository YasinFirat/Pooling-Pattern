using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script example for Pooling
/// </summary>
public class CallPoolObject : MonoBehaviour
{
    public float randomMinX = 0;
    public float randomMinZ = 0;
    public float randomMaxX = 0;
    public float randomMaxZ= 0;

    void Create(PoolNames poolNames)
    {
       
        PoolManager.Instance.PullFromPool(poolNames, new 
            Vector3(Random.Range(randomMinX,randomMaxX),0,Random.Range(randomMinZ,randomMaxZ)));

    }
    void RandomDestroy(PoolNames poolNames)
    {
        //this method is bad but I used it to get you to grasp the pooling pattern method.
        PoolMember[] member = FindObjectsOfType<PoolMember>();
        if (member == null)
            return;
        foreach (PoolMember item in member)
        {
            if (item.POOLNAMES == poolNames)
            {
                item.gameObject.SetActive(false);
                return;
            }
          
        }
    }
    public void CreateBlue()
    {
        Create(PoolNames.blue);

    }
    public void DestroyBlue()
    {
        RandomDestroy(PoolNames.blue);

    }
    public void CreateRed()
    {
        Create(PoolNames.red);

    }
    public void DestroyRed()
    {
        RandomDestroy(PoolNames.red);

    }
    public void CreateGreen()
    {
        Create(PoolNames.green);

    }
    public void DestroyGreen()
    {
        RandomDestroy(PoolNames.green);
    }


}
