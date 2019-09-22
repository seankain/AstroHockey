using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunishRocket : Rocket
{
    private float time = 0;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        var killable = other.gameObject.GetComponentInParent<Killable>();
        //var tetromino = other.gameObject.GetComponentInParent<Tetromino>();
        var ponger = other.gameObject.GetComponentInParent<Ponger>();
        if (killable != null && other == killable.HitCollider)
        {
            Debug.Log($"hit {other.name}");
            Destroy(gameObject);
            //killable.Die();
            var agent = killable.GetComponent<PlayerAgent>();
            if(agent != null) { agent.SetReward(-1.0f); agent.Done(); }
            return;
        }
        if (ponger != null)
        {
            ponger.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Direction * 100, gameObject.transform.position);
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= MaxTime)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            gameObject.transform.position += Direction * Speed;
        }
    }
}
