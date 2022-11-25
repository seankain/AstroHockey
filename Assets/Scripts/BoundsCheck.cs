using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck
{
    private Camera cam;
    private Rect gameBoundaries;
    private Vector3 bottomLeft;
    private Vector3 topRight;
    

    public BoundsCheck(Camera camera)
    {
        cam = camera;
        gameBoundaries = new Rect();
        bottomLeft = cam.ViewportToWorldPoint(Vector3.zero);
        topRight = cam.ViewportToWorldPoint(new Vector3(1, 0, 1));
        gameBoundaries.xMin = bottomLeft.x;
        gameBoundaries.yMin = bottomLeft.z;
        gameBoundaries.xMax = topRight.x;
        gameBoundaries.yMax = topRight.y;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(bottomLeft, Vector3.one);
        Gizmos.DrawCube(topRight, Vector3.one);
    }

    public bool IsOutOfBounds(Vector3 position)
    {
        return position.x > gameBoundaries.xMax || position.x < gameBoundaries.xMin || position.z > gameBoundaries.yMax || position.z < gameBoundaries.yMin;
    }

    public bool[] Check(Vector3 position)
    {
        //0 = x
        //1 = y
        return new bool[] { position.x >= gameBoundaries.xMax || position.x < gameBoundaries.xMin, position.z >= gameBoundaries.yMax || position.z <= gameBoundaries.yMin };
    }

}
