using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float TurnSpeed = 5;
    public float MaxThrust = 5;
    public float currentThrust = 0;
    private Vector3 thrustVector;
    bool thrusting = false;
    private Rigidbody rb;

    Transform t;
    private GameObject currentRocket = null;
    private Weapon weapon;
    private ThrusterVisuals thrusterVisuals;

    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        thrustVector = t.position;
        thrusterVisuals = gameObject.GetComponent<ThrusterVisuals>();
    }

    void Fire()
    {
        weapon.Fire();
    }

    private void FixedUpdate()
    {
        if (thrusting)
        {
            rb.AddForce(t.forward);
        }
        thrusterVisuals.ToggleThruster(thrusting);
    }

    // Update is called once per frame
    void Update()
    {
        t = gameObject.transform;
        currentThrust--;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            t.RotateAround(t.position, Vector3.up, -TurnSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            t.RotateAround(t.position, Vector3.up, TurnSpeed);
        }
        thrusting = Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }
}
