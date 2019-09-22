using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TetrominoTypes
{
    I, O, T, J, L, S, Z
}

/*
 * 0,1,2,3,
 * 4,5,6,7,
 * 8,9,10,11,
 * 12,13,14,15
 * 
 * 
 * I
 * 1,1,1,1,
 * 0,0,0,0,
 * 0,0,0,0,
 * 0,0,0,0
 * 
 * O
 * 1,1,0,0
 * 1,1,0,0
 * 0,0,0,0
 * 
 * T
 * 0,0,0,0,
 * 0,1,0,0,
 * 1,1,1,0
 * 
 * J
 * 0,1,1,1
 * 0,0,0,1
 * 0,0,0,0
 * 
 * L
 * 0,0,0,1
 * 0,1,1,1
 * 0,0,0,0
 * 
 * S
 * 0,0,1,1
 * 0,1,1,0
 * 0,0,0,0
 * 0,0,0,0
 * 
 * Z
 * 1,1,0,0
 * 0,1,1,0
 * 0,0,0,0
 * 
 * 
 * */

public class Tetromino : MonoBehaviour
{
    public TetrominoTypes TetrominoType;
    public float TimeDelay = 1.0f;
    public float TetrominoScale = 0.5f;
    private float elapsed = 0.0f;
    public GameObject TetrominoCubePrefab;
    private Vector3 groundPosition = new Vector3(0, 0, -5);
    private int tetrominoValue;
    public bool IsFalling { get; private set; } = true;
    private List<TetrominoCell> cells = new List<TetrominoCell>();
    private Vector3 center;

    private short[][] layouts = {
        new short[]{0,1,2,3},
        new short[]{0,1,4,5},
        new short[]{5,8,9,10 },
        new short[]{1,2,3,7 },
        new short[]{3,5,6,7 },
        new short[]{2,3,5,6},
        new short[]{0,1,5,6 }
    };

    private Vector3[] locations = {
        new Vector3(0,0,0),
        new Vector3(1,0,0),
        new Vector3(2,0,0),
        new Vector3(3,0,0),
        new Vector3(0,0,1),
        new Vector3(1,0,1),
        new Vector3(2,0,1),
        new Vector3(3,0,1),
        new Vector3(0,0,2),
        new Vector3(1,0,2),
        new Vector3(2,0,2),
        new Vector3(3,0,2),
        new Vector3(0,0,3),
        new Vector3(1,0,3),
        new Vector3(2,0,3),
        new Vector3(3,0,3)
    };

    // Start is called before the first frame update
    void Start()
    {
        //this.tetrominoValue = Random.Range(0, 6);
        //this.TetrominoType = (TetrominoTypes)tetrominoValue;
        //BuildTetromino();

    }

    private void Awake()
    {
        this.tetrominoValue = Random.Range(0, 6);
        this.TetrominoType = (TetrominoTypes)tetrominoValue;
        BuildTetromino();
    }

    private void BuildTetromino()
    {
        var layout = this.layouts[tetrominoValue];
        var sum = Vector3.zero;
        for (var i = 0; i < layout.Length; i++)
        {
            var cellObj = Instantiate(TetrominoCubePrefab, locations[layout[i]] * TetrominoScale, Quaternion.identity, null);
            sum += cellObj.transform.position;
            cells.Add(cellObj.GetComponent<TetrominoCell>());
        }
         this.center = sum / cells.Count;
        this.transform.position = this.center;
        foreach (var cell in cells) {
            cell.transform.parent = this.transform;
        }

    }

    private bool CheckCanFall()
    {
        var canFall = true;
        foreach (var cell in cells)
        {
            if (cell.Locked)
            {
                canFall =  false;
            }
        }
        if (!canFall)
        {
            foreach (var cell in cells)
            {
            }
        }
        return canFall;
    }

    public List<Vector3> GetUpdatedPositions(Vector3 delta) {
        var positions = new List<Vector3>();
        foreach (var cell in cells)
        {
            positions.Add(cell.transform.position + delta);
        }
        return positions;
    }

    public bool CellAt(Vector3 position)
    {
        foreach (var cell in cells) {
            if (cell.transform.position == position) { return true; }
        }
        return false;
    }

    public void Rotate()
    {
        this.transform.Rotate(Vector3.up, 90, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        //this.Rotate();
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
