using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveMind : MonoBehaviour
{

    [SerializeField] private Boid boidPrefab;
    [SerializeField] private int numberofboids = 100; // private can only be used by this class
    [SerializeField] private Vector3 size = new Vector3(60,60,60);
    private List<Boid> boids;
    [SerializeField] private int accCohesion;

    // Start is called before the first frame update
    void Start()
    {
        boids = new List<Boid>();
        for (int i = 0; i < numberofboids; i++)
        {
            var boid = Instantiate(boidPrefab);
            boid.transform.position = new Vector3(Random.Range(-size.x/2, size.x/2),
                                                  Random.Range(-size.y/2, size.y/2),
                                                  Random.Range(-size.z/2, size.z/2));
            
            boids.Add(boid);
        }

        FindObjectOfType<Camera>().GetComponent<CameraController>().followThatBoid = boids[0];

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCohesionVelocity();
    }

    void UpdateCohesionVelocity()
    {
        Vector3 com= GetCentreofMass(); //constructor
        // foreach(var b in boids) //range based loops
        // {
        //     com += b.transform.position;
        // }
        // com /= numberofboids;

        foreach(var b in boids)
        {
            b.velocity += (com - b.transform.position).normalized * Time.deltaTime * accCohesion;
        }
    }

    public Vector3 GetCentreofMass()
    {
        Vector3 com= new Vector3(); //constructor
        foreach(var b in boids) //range based loops
        {
            com += b.transform.position;
        }
        com /= numberofboids;
        return com;
    }
}
