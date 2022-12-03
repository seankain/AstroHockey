using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour
{
    public float AngleThreshold = 5;
    public float MoveSpeed = 10;
    public float TurnSpeed = 5f;
    public float MaxTravelDistance = 7.5f;
    public float DirectionTravelTime = 1;
    private int direction = 1;
    private Weapon weapon;
    private Puck puck;


    private float gameSpaceLeft { get { return -MaxTravelDistance + gameObject.transform.position.z; } }
    private float gameSpaceRight { get { return MaxTravelDistance - gameObject.transform.position.z; } }

    private Vector3 currentDestination;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();
        puck = FindObjectOfType<Puck>();
    }

    private void Fire()
    {
        weapon.Fire();
    }

    private void Move()
    {
        currentDestination = new Vector3(0, 0, Random.Range(0, direction * MaxTravelDistance));

    }

    private void GetNextLocation()
    {
        var angle = Vector3.Angle(transform.position, puck.gameObject.transform.position);
        var destination = puck.gameObject.transform.position;
        var distance = Vector3.Distance(transform.position, puck.gameObject.transform.position);
    }

    private void GetNextLookInput() { }

    // Update is called once per frame
    void Update()
    {
        //Get the angle between our forward and the puck
        puck = FindObjectOfType<Puck>();
        var angle = -Vector3.SignedAngle((puck.transform.position - transform.position), transform.forward, Vector3.up);
        //var angle = Vector3.SignedAngle(transform.forward, puck.gameObject.transform.position, Vector3.up);
        Debug.Log(angle);
        //var angle = Vector3.Angle(transform.position, puck.gameObject.transform.position);
        //If it is greater than absolute value of some threshold do a turn maneuver
        if (Mathf.Abs(angle) > AngleThreshold)
        {
            var turnDirection = 1;
            if (angle < 0) { turnDirection = -1; }
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, (turnDirection) * TurnSpeed * Time.deltaTime);
        }
        else
        {
            weapon.Fire();
        }

    }
}
