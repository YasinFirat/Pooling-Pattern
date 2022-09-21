using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableWithNames
{
    /// <summary>
    /// The object goes back to the pool where it was extracted.
    /// </summary>
    /// <param name="POOLNAMES">The enum tag of the Pool of which it is a member</param>
    /// <param name="gameObject">Object that needs to go to the pool</param>
    void BackToPool(PoolNames POOLNAMES, GameObject gameObject);
    /// <summary>
    ///  The object is called up and removed from the pool for use.
    /// </summary>
    /// <param name="POOLNAMES">The enum tag of the Pool of which it is a member</param>
    /// <returns></returns>
    GameObject PullFromPool(PoolNames POOLNAMES);
    /// <summary>
    /// The object is called up with position and removed from the pool for use.
    /// </summary>
    /// <param name="POOLNAMES">The enum tag of the Pool of which it is a member</param>
    /// <param name="_position"> </param>
    /// <returns></returns>
    GameObject PullFromPool(PoolNames POOLNAMES, Vector3 _position);
    /// <summary>
    ///  The object is called up with are position and rotation
    /// </summary>
    /// <param name="POOLNAMES"></param>
    /// <param name="_position"></param>
    /// <param name="_rotation"></param>
    /// <returns></returns>
    GameObject PullFromPool(PoolNames POOLNAMES, Vector3 _position, Quaternion _rotation);
}
