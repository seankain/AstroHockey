using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var goal = other.gameObject.GetComponentInParent<Goal>();
        if (goal != null)
        {
            Debug.Log("Puck on trigger enter");
            goal.OnScored.Invoke();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
