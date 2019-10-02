using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaries : MonoBehaviour
{
    public float wrapOffset =3;
    private Rect gameBoundaries;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        var bottomLeft = cam.ViewportToWorldPoint(Vector3.zero);
        var topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 1));
        gameBoundaries.xMin = bottomLeft.x;
        gameBoundaries.yMin = bottomLeft.z;
        gameBoundaries.xMax = topRight.x;
        gameBoundaries.yMax = topRight.y;
        Debug.Log(gameBoundaries.ToString());
    }

    public Vector3 GetWrappedPosition(GameObject wrapObject)
    {
        bool wrapping = false;
        Vector3 wrappedPosition = wrapObject.transform.position;
        if (wrapObject.transform.position.x > gameBoundaries.xMax) {
            wrappedPosition.x = gameBoundaries.xMin + wrapOffset;
            wrapping = true;
        }
        if (wrapObject.transform.position.x < gameBoundaries.xMin) {
            wrappedPosition.x = gameBoundaries.xMax - wrapOffset;
            wrapping = true;
        }
        if (wrapObject.transform.position.z > gameBoundaries.yMax) {
            wrappedPosition.z = gameBoundaries.yMin + wrapOffset;
            wrapping = true;
        }
        if (wrapObject.transform.position.z < gameBoundaries.yMin) {
            wrappedPosition.z = gameBoundaries.yMax - wrapOffset;
            wrapping = true;
        }
        if (wrapping == true) {
            Debug.Log("should be wrapping");
        }
        return wrappedPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
