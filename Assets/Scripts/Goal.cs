using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public GameObject ScoringZone;
    public bool IsPlayerOneGoal = true;
    public delegate void Scored();
    public Scored OnScored;
    public Material PrimaryMaterial;
    public Material SecondaryMaterial;

    private void OnTriggerEnter(Collider other)
    {

        var puck = other.GetComponentInParent<Puck>();
        if (puck != null)
        {
            if (OnScored != null)
            {
                Debug.Log("Goal scored");
                OnScored.Invoke();
            }
            Destroy(puck);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!IsPlayerOneGoal)
        {
            ScoringZone.GetComponent<MeshRenderer>().material.SetColor(SecondaryMaterial.name, SecondaryMaterial.color);
        }
    }
}
