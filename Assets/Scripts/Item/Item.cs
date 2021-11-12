using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    internal Item Equip(Transform palm)
    {
        transform.parent = palm;
        transform.position = palm.TransformPoint(Vector3.forward * 1.5f);
        transform.rotation = palm.rotation;

        return this;
    }

    internal Item Drop(Transform palm) 
    {
        transform.parent = null;

        return null;
    }

    internal abstract void Use();

    internal abstract void StopUse();
}
