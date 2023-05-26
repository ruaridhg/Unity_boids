using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3 (0.0f, 1.0f, 0.0f);
    [SerializeField] float distance = 5.0f;
    public Boid followThatBoid;
    private bool FollowToggle = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(followThatBoid.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FollowToggle)
        {
            FollowBoid();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            FollowToggle = !FollowToggle;
            if(!FollowToggle)
            {
                ResetCamera();
            }
        }
        
    }

    private void ResetCamera()
    {
        transform.position = new Vector3(0f,0f,0f);
        Vector3 com = FindObjectOfType<HiveMind>().GetCentreofMass();
        transform.LookAt(com);
    }
    private void FollowBoid()
    {
        transform.position = followThatBoid.transform.position - distance*followThatBoid.velocity.normalized;
        transform.LookAt(followThatBoid.transform.position);
    }
}
