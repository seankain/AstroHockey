using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{

    public AudioSource CollisionAudioSource;
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

    private void OnCollisionEnter(Collision collision)
    {
        CollisionAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
