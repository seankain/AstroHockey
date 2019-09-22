using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TetrominoCell : MonoBehaviour
{
    public bool Locked = false;
    private TetrominoGrid grid;

    public void Disassociate()
    {
        this.transform.SetParent(null);
    }

    // Start is called before the first frame update
    void Start()
    {
        //grid = FindObjectOfType<TetrominoGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Locked) { return; }
        //var nextPosition = this.transform.position - new Vector3(0,0,1);
        //if (FindObjectsOfType<TetrominoCell>().Any(c => c.transform.position == nextPosition)) {
        //    Locked = true;
        //};
    }
}
