using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTesting : MonoBehaviour
{

    public Rigidbody Subject;
    public float DelaySeconds = 5f;
    public Vector3 ForceDirection = Vector3.right;
    private float elapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed >= DelaySeconds)
        {
            elapsed = 0;
            Subject.AddForce(ForceDirection, ForceMode.VelocityChange);
        }
    }
}
