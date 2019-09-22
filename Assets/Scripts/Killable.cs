using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public Collider HitCollider;
    public delegate void OnKilledDelagate();

    public OnKilledDelagate OnKilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Die()
    {
        Destroy(gameObject);
        if (OnKilled != null)
        {
            Debug.Log(gameObject.name + " on killed invoke");
            OnKilled.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
