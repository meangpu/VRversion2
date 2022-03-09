using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTX : MonoBehaviour
{
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();

    }

    void Update()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
        localVelocity.y = 0;
        localVelocity.z = 0;
                
        rigidbody.velocity = transform.TransformDirection(localVelocity);
    }
}
