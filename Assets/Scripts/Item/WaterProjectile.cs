using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(0, 30f, 0, ForceMode.Impulse);
        StartCoroutine(DestroyWaterProjectile());
    }

    private IEnumerator DestroyWaterProjectile()
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
