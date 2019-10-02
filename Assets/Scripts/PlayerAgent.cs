using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class PlayerAgent : Agent
{

    public TrainingGoal GoalLocation;
    public TrainingGoal OtherGoalLocation;
    public Transform PuckLocation;
    public Transform OtherPlayer;
    public Vector3 spawnerPosition;
    public float speed = 10;
    public float TurnSpeed = 5;
    
    private Rigidbody puckRigidBody;
    private Rigidbody otherPlayerRigidBody;
    private Rigidbody rb;
    private int currentThrust = 0;
    private Thruster thruster;

    private Weapon weapon;

    private bool goalScored = false;
    private bool opponentScored = false;

    private float idleTime = 0;
    private float prevDistanceToGoal = float.PositiveInfinity;
    private BoundsCheck boundsChecker;
    private float outOfBoundsTime = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        otherPlayerRigidBody = OtherPlayer.GetComponent<Rigidbody>();
        puckRigidBody = PuckLocation.GetComponent<Rigidbody>();
        thruster = GetComponent<Thruster>();
        GoalLocation.OnScored += () => { goalScored = true; };
        OtherGoalLocation.OnScored += () => { opponentScored = true; };
        weapon = GetComponent<Weapon>();
        prevDistanceToGoal = Vector3.Distance(PuckLocation.position, GoalLocation.transform.position);
        boundsChecker = new BoundsCheck(Camera.main);
        
    }

    public override void AgentReset()
    {
        // Move the target to a new spot
        PuckLocation.position = new Vector3(Random.Range(-8,8),
                                      spawnerPosition.y,
                                      Random.Range(-5,5));

        OtherPlayer.position = new Vector3(Random.Range(-9,9), 0,Random.Range(-5,5));
        goalScored = false;
        opponentScored = false;
        outOfBoundsTime = 0;
    }

    public override void CollectObservations()
    {
        // Target and Agent positions
        AddVectorObs(GoalLocation.transform.position);
        AddVectorObs(PuckLocation.position);
        AddVectorObs(OtherPlayer.position);
        AddVectorObs(this.transform.position);
        AddVectorObs(OtherGoalLocation);

        // Agent velocity
        AddVectorObs(rb.velocity.x);
        AddVectorObs(rb.velocity.z);
        //Puck velocity
        AddVectorObs(puckRigidBody.velocity.x);
        AddVectorObs(puckRigidBody.velocity.y);
        AddVectorObs(otherPlayerRigidBody.velocity.x);
        AddVectorObs(otherPlayerRigidBody.velocity.y);
        
    }

    /// <summary>
    /// Possible agent actions:
    /// Turn Clockwise, Turn AntiClockwise, Thrust, Shoot
    /// </summary>
    /// <param name="vectorAction"></param>
    /// <param name="textAction"></param>
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Actions, size = 4
        var shoot = vectorAction[0];
        var turnLeft = vectorAction[1];
        var turnRight = vectorAction[2];
        var thrust = vectorAction[3];
        var idle = true;
        //Vector3 controlSignal = Vector3.zero;
        //controlSignal.x = vectorAction[0];
        //controlSignal.z = vectorAction[1];
        //rb.AddForce(controlSignal * speed);
        if (shoot == 1) { idle = false; weapon.Fire(); }
        if (turnLeft == 1) { idle = false; transform.RotateAround(transform.position, Vector3.up, -TurnSpeed); }
        if (turnRight == 1) { idle = false; transform.RotateAround(transform.position, Vector3.up, TurnSpeed); }
        if (thrust == 1) { idle = false; thruster.IsThrusting = true; } else { thruster.IsThrusting = false; }

        if (idle) {
            SetReward(-0.05f);
        }

        if (boundsChecker.IsOutOfBounds(transform.position))
        {
            outOfBoundsTime += Time.deltaTime;
            if (outOfBoundsTime > 5) { SetReward(-1); Done(); }
            SetReward(-0.2f);

        }

        // Rewards
        float distanceToTarget = Vector3.Distance(PuckLocation.position,
                                                  GoalLocation.transform.position);
        if (distanceToTarget < prevDistanceToGoal)
        {
            SetReward(0.05f);
        }
        else
        {
            SetReward(-0.01f);
        }
        prevDistanceToGoal = distanceToTarget;

        // Reached target
        if (goalScored)
        {
            SetReward(1.0f);
            Done();
        }

        // scored in other goal
        if (opponentScored)
        {
            SetReward(-1f);
            Done();
        }

    }
}
