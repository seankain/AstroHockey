using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 0.1f;
    public float MaxTime = 5;
    public GameObject Originator;
    
    private float time = 0;
    public Vector3 Direction { get; private set; } =new Vector3(0, 0, 0);
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
            killable.Die();
            return;
        }
        if(ponger != null)
        {
            ponger.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Direction * 100, gameObject.transform.position);
            Destroy(gameObject);
        }

    }

    public void SetDirectionAndOrigin(Vector3 direction, GameObject originator)
    {
        Direction = direction;
        Originator = originator;
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
