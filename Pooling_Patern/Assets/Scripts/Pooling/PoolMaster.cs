using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was created to be accessed from everywhere
/// </summary>
public abstract class PoolMaster : MonoBehaviour
{
    private PoolManager _poolManager;


    public PoolManager poolManager
    {
        get
        {
            if (_poolManager == null)
            {
                _poolManager = FindObjectOfType<PoolManager>();
            }
            return _poolManager;
        }
    }
}
