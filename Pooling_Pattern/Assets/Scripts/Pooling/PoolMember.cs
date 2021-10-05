using UnityEngine;
/// <summary>
/// Every pool member has this script.
/// When the member wants to go to the pool again, member applies to this class.
/// 
/// </summary>
public class PoolMember: MonoBehaviour
{
    public Pooling pooling;
    public PoolNames poolNames;
   
    public PoolMember SetPoolNames(PoolNames _poolNames)
    {
        poolNames = _poolNames;
        return this;
    }
   
    /// <summary>
    /// If you do not know which pool the object belongs to, 
    /// you can send the object to its repository with this method.
    /// </summary>
    void GoBackToPool()
    {
         PoolManager.Instance.BackToPool(poolNames, this.gameObject);
        
    }
    private void OnDisable()
    {
        //Don't worry, this method is here :)
        GoBackToPool();
    }


}