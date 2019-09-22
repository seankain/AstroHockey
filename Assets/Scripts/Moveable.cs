using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit tetromino");
        var rocket =collision.rigidbody.gameObject.GetComponent<Rocket>();
        if (rocket != null)
        {
            this.transform.position += collision.impulse;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //this.transform.Rotate(new Vector3(0,1,0), 90);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
