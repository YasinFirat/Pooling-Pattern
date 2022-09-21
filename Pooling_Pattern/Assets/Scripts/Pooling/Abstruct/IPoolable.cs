using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    /// <summary>
    ///The object is sent back to the pool.
    /// </summary>
    /// <param name="gameObject"></param>
    void AddPool(GameObject gameObject);
    /// <summary>
    /// The object is called up and removed from the pool for use.
    /// </summary>
    /// <param name="_position">object's location</param>
    /// <returns></returns>
    GameObject PullFromPool(Vector3 _position);

    /// <summary>
    /// The object is called up and removed from the pool for use.
    /// </summary>
    /// <param name="_position"></param>
    /// <param name="_rotation"></param>
    /// <returns></returns>
    GameObject PullFromPool(Vector3 _position, Quaternion _rotation);
}
