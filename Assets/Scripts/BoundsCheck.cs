using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck
{
    private Camera cam;
    private Rect gameBoundaries;
    

    public BoundsCheck(Camera camera)
    {
        cam = camera;
        gameBoundaries = new Rect();
        var bottomLeft = cam.ViewportToWorldPoint(Vector3.zero);
        var topRight = cam.ViewportToWorldPoint(new Vector3(1, 0, 1));
        gameBoundaries.xMin = bottomLeft.x;
        gameBoundaries.yMin = bottomLeft.z;
        gameBoundaries.xMax = topRight.x;
        gameBoundaries.yMax = topRight.y;
    }

    public bool IsOutOfBounds(Vector3 position)
    {
        return position.x > gameBoundaries.xMax || position.x < gameBoundaries.xMin || position.z > gameBoundaries.yMax || position.z < gameBoundaries.yMin;
    }

}
