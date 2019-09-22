using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingGoal : MonoBehaviour
{
    // Start is called before the first frame update

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
            puck.transform.position = new Vector3(Random.value, 1, Random.value);
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
