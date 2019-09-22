using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed = 10;
    public float MaxTravelDistance = 7.5f;
    public float DirectionTravelTime = 1;
    private int direction = 1;
    private Weapon weapon;


    private float gameSpaceLeft { get { return -MaxTravelDistance + gameObject.transform.position.z; } }
    private float gameSpaceRight { get { return MaxTravelDistance - gameObject.transform.position.z; } }

    private Vector3 currentDestination;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();   
    }

    private void Fire()
    {
        weapon.Fire();
    }

    private void Move()
    {
       currentDestination =  new Vector3(0,0,Random.Range(0, direction * MaxTravelDistance));
        
    }

    private void GetNextLocation()
    {
        var puck = FindObjectOfType<Puck>();
        var angle = Vector3.Angle(transform.position, puck.gameObject.transform.position);
        var destination = puck.gameObject.transform.position;
        var distance = Vector3.Distance(transform.position, puck.gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
