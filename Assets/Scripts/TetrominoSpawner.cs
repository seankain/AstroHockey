using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    public float Width = 20;
    public float FrequencyHz = 0.2f;
    private float elapsed = 0.0f;
    private float timeToSpawn { get { return 1 / FrequencyHz; } }
    public GameObject TetrominoPrefab;
    private Tetromino currentTetromino;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if(currentTetromino != null && currentTetromino.IsFalling) { return; }
        if (elapsed >= timeToSpawn)
        {
            var tetroObject = Instantiate(TetrominoPrefab, this.transform.position, Quaternion.identity);
            currentTetromino = tetroObject.GetComponent<Tetromino>();
        }
    }
}
