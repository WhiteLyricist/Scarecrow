using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 10f;

    private void Start()
    {
        StartCoroutine(DestroyBullit());
    }

    void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

    private IEnumerator DestroyBullit() 
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
