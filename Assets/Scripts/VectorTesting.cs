using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTesting : MonoBehaviour
{
    public float DelaySeconds = 5;
    public float OffsetMagnitude = 1;
    private float elapsed = 0;
    private Puck puck;
    private Goal goal;
    private ComputerPlayer enemy;
    // Start is called before the first frame update
    void Start()
    {
        puck = FindObjectOfType<Puck>();
        goal = FindObjectOfType<Goal>();
        enemy = FindObjectOfType<ComputerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= DelaySeconds) {
            elapsed = 0;
            DumpInfo();
        }
    }

    private void DumpInfo()
    {
        var normed = Vector3.Normalize(puck.transform.position - goal.transform.position);
        var location = puck.transform.position + normed * OffsetMagnitude;
        enemy.transform.position = location;
        enemy.transform.LookAt(puck.transform);
        //enemy.transform.LookAt(new Vector3(puck.transform.position.x, 1, puck.transform.position.z));
        //enemy.transform.rotation.SetLookRotation(puck.transform.position);
    }
}
