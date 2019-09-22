using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraps : MonoBehaviour
{
    private Renderer[] renderers;
    private Camera cam;
    private LevelBoundaries levelBoundaries;
    private bool isWrappingX = false;
    private bool isWrappingZ = false;
    private Rect gameBoundaries;
    private Vector3 prevPosition;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        cam = Camera.main;
        var bottomLeft = cam.ViewportToWorldPoint(Vector3.zero);
        var topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 1));
        gameBoundaries.xMin = bottomLeft.x;
        gameBoundaries.yMin = bottomLeft.z;
        gameBoundaries.xMax = topRight.x;
        gameBoundaries.yMax = topRight.y;
        prevPosition = transform.position;
    }

    bool CheckRenderers()
    {
        foreach (var renderer in renderers)
        {
            // If at least one render is visible, return true
            if (renderer.isVisible)
            {
                return true;
            }
        }

        // Otherwise, the object is invisible
        return false;
    }

    private void Update()
    {
        var isVisible = CheckRenderers();
        if (isVisible)
        {
            isWrappingX = false;
            isWrappingZ = false;
            return;
        }

        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;

        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;
           isWrappingX = true;
        }

        if (!isWrappingZ && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.z = -(newPosition.z);
            isWrappingZ = true;
        }
        Debug.Log($"isVisible, wrapping x: {isWrappingX} wrapping z: {isWrappingZ}");
        transform.position = newPosition;

    }
}
