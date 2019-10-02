using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponger : MonoBehaviour
{

    private Renderer[] renderers;
    private Camera cam;
    private bool isBouncingX = false;
    private bool isBouncingZ = false;
    private Rigidbody rb;
    private BoundsCheck boundsCheck;
    private bool outOfBounds = false;
    private float outOfBoundsTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        boundsCheck = new BoundsCheck(cam);
    }

    bool CheckRenderers()
    {
        foreach (var renderer in renderers)
        {
            // If at least one render is visible, return true
            if (renderer.isVisible)
            {
                return true;
            }
        }

        // Otherwise, the object is invisible
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 8)
        {
            Debug.Log("Hit ponger boundary");
            rb.velocity = (rb.velocity) * -1;
            return;
        }
        //if (collision.rigidbody != null && !string.IsNullOrEmpty(collision.gameObject.name))
        //{
        //    Debug.Log($"collision {collision.rigidbody.gameObject.name}");
        //}
        //if(collision.rigidbody == null) { rb.velocity = (rb.velocity * 0.9f) * -1; return; }
        var rocket = collision.rigidbody.gameObject.GetComponent<Rocket>();
        if (rocket != null)
        {
            rb.AddForceAtPosition(collision.relativeVelocity,collision.GetContact(0).point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"collision {other.gameObject.name}");
        var rocket = other.gameObject.GetComponent<Rocket>();
        if (rocket != null)
        {
            var rb = rocket.GetComponent<Rigidbody>();
            rb.AddForce(rb.velocity,ForceMode.VelocityChange);
            //rb.AddForceAtPosition(rb.velocity * 1000, rb.position);
        }
    }

    //private void Update()
    //{
    //    var viewportPosition = cam.WorldToViewportPoint(transform.position);

    //    if (viewportPosition.x >= 1 || viewportPosition.x <= 0 || viewportPosition.y >= 1 || viewportPosition.y <= 0)
    //    {
    //        rb.velocity = (rb.velocity * 0.9f) * -1;
    //    }

    //    //if (viewportPosition.y >= 1 || viewportPosition.y <= 0)
    //    //{
    //    //    rb.velocity = rb.velocity * -1;
    //    //}

    //}
}
