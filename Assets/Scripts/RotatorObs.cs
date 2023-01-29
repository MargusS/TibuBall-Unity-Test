using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorObs : MonoBehaviour
{
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * 1.5f); 
    }
}
