using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoGrid : MonoBehaviour
{
    public float CellSize = 0.4f;
    public float Width = 25;
    public float Height = 10;
    public float DropFrequencyHz = 0.2f;
    public float SpawnFrequencyHz = 0.5f;
    public float BottomZ = -5f;
    public GameObject TetrominoPrefab;
    private Tetromino currentTetromino;
    private Vector3 dropVector = new Vector3(0, 0, -1);
    private float elapsed = 0.0f;
    private float timeToSpawn { get { return 1 / SpawnFrequencyHz; } }
    private float timeToDrop { get { return 1 / DropFrequencyHz; } }
    private Vector3 SpawnLocation { get { return new Vector3(0,5,5); } }
    private List<Tetromino> tetrominos = new List<Tetromino>();
    private LineRenderer gridDebugRenderer;
    private int[][] cells;


    // Start is called before the first frame update
    void Start()
    {
        gridDebugRenderer = GetComponent<LineRenderer>();
      
        //for (var i = 0; i < Width; i++) {
        //    for (var j = 0; j < Height; j++) {
                
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        //check if there is already a tetromino falling
        if (currentTetromino != null && currentTetromino.IsFalling)
        {
            if (elapsed >= DropFrequencyHz)
            {
                var fits = true;
                var nextPositions = currentTetromino.GetUpdatedPositions(dropVector);
                foreach (var position in nextPositions)
                {
                    if (position.z < BottomZ || !DoesFit(position)) { fits = false; break; }
                }
                if (fits)
                {
                    // currentTetromino.transform.parent.position += dropVector;

                }
                elapsed = 0;
            }
            return;
        }
        if (elapsed >= timeToSpawn)
        {
            var tetroObject = Instantiate(TetrominoPrefab,SpawnLocation, Quaternion.identity,null);
            //why this happen
            tetroObject.transform.position += new Vector3(0, 1, 0);
            //tetroObject.transform.position += new Vector3(0, 6, 0);
            currentTetromino = tetroObject.GetComponent<Tetromino>();
            tetrominos.Add(currentTetromino);
        }
        //check grid rows to check for full

    }

    private bool DoesFit(Vector3 position) {
        foreach (var t in tetrominos)
        {
            if (t.CellAt(position))
            {
                return false;
            }
        }
        return true;
    }

}
