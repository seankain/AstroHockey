using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetTurn()
    {
        return Input.GetAxis("Horizontal");
    }
    public float GetThrust()
    {
        return Input.GetAxis("Vertical");
    }
    public bool GetShoot() 
    {
        return Input.GetAxis("Fire") > 0;
    }

}
