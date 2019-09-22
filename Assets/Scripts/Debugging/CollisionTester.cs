using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    [SerializeField]
    private Rocket rocket;
    [SerializeField]
    private GameObject thingToCollideWith;
    private Vector3 prevRocketPosition;

    // Start is called before the first frame update
    void Start()
    {

        //var direction = rocket.transform.position - tetromino.transform.position;
        //rocket.SetDirectionAndOrigin(direction, this.gameObject);
        prevRocketPosition = rocket.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rocket != null)
        {
            rocket.transform.position = Vector3.MoveTowards(rocket.transform.position, thingToCollideWith.transform.position, 0.1f);
            rocket.transform.rotation.SetLookRotation(thingToCollideWith.transform.position);
        }
        //rocket.SetDirectionAndOrigin(tetromino.transform.position,this.gameObject);

        //var prevDistance = Vector3.Distance(prevRocketPosition, tetromino.transform.position);
        //if (Vector3.Distance(rocket.transform.position, tetromino.transform.position) > prevDistance)
        //{
        //    rocket.SetDirectionAndOrigin(tetromino.transform.position, this.gameObject);
        //}
        
    }
}
