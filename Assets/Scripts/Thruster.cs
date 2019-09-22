using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{

    private Rigidbody rb;
    private ThrusterVisuals thrusterVisuals;
    
    public bool IsThrusting { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrusterVisuals = GetComponent<ThrusterVisuals>();
    }

    private void FixedUpdate()
    {
        if (IsThrusting)
        {
            rb.AddForce(transform.forward);
        }
        thrusterVisuals.ToggleThruster(IsThrusting);
    }

}
