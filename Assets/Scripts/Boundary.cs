using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Boundary : MonoBehaviour
{
    private LevelBoundaries boundaries;
    private Killable currentIntersector;

    // Start is called before the first frame update
    void Start()
    {
        boundaries = FindObjectOfType<LevelBoundaries>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Killable>())
        {
            other.gameObject.transform.position = boundaries.GetWrappedPosition(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
