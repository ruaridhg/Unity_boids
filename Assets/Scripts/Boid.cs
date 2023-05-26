using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

    public Vector3 velocity;
    // private Rigidbody physicsBody;
    // Start is called before the first frame update
    void Start()
    {
        // physicsBody = GetComponent<Rigidbody>();
        // physicsBody.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime; // deltaTime is time for frame
        transform.LookAt(transform.position + velocity);
    }
}
