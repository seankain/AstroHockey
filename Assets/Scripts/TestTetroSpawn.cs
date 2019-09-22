using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTetroSpawn : MonoBehaviour
{
    public GameObject tetroprefab;

    // Start is called before the first frame update
    void Start()
    {
        var obj = Instantiate(tetroprefab,new Vector3(0,1,0),Quaternion.identity,null);
        obj.transform.position += new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
