using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Build pools here
/// </summary>
public class PoolManager : PoolOperations
{
    #region Singleton
    public static PoolManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        FillPool();
    }
    #endregion
    
   
}
