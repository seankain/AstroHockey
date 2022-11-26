using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Blue,
    Red
};

public class Ship : MonoBehaviour
{
    public float TurnSpeed = 5;
    public float MaxThrust = 5;
    public Team Team;
    public Material BlueTeamMaterial;
    public Material RedTeamMaterial;
    public GameObject TeamBadge;

    public void SetTeam(Team team)
    {
        Team = team;
        var meshRenderer = TeamBadge.GetComponent<MeshRenderer>();
        if (team == Team.Blue)
        {
            meshRenderer.material.color = Color.blue;
            //meshRenderer.material = BlueTeamMaterial;
            return;
        }
        meshRenderer.material.color = Color.red;
        //meshRenderer.material = RedTeamMaterial;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
