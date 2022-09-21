using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject
{
    private GameObject gameObject;
    
    public bool isActive
    {
        get
        {
            return gameObject.activeInHierarchy;
        }
    }
    public void SetPoolObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
    public GameObject getPoolObject
    {
        get
        {
            gameObject.SetActive(true);
            return gameObject;
        }
       
    }
    public PoolObject SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
        return this;
    }
    public PoolObject SetRotation(Quaternion rotation)
    {
        gameObject.transform.rotation = rotation;
        return this;
    }
}
