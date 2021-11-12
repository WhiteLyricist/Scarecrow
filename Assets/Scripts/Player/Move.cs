using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("Control Script/Move")]

public class Move : MonoBehaviour
{

    public float speed = 6.0f;
    public float gravity = -9.8f;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = transform.TransformDirection(movement);

        _rigidbody.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);
    }
}
