﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWay : MonoBehaviour
{
    public enum PathTypes
    {
        linear
    }

    public PathTypes PathType;
    public int movementDirection = 1;
    public int moveingTo = 0;
    public Transform[] PathElements;
    public static bool StartFEye = false;

    public void OnDrawGizmos()
    {
        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }

        for (var i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while(true)
        {
            print(PathElements.Length);
            yield return PathElements[moveingTo];

            if (PathElements.Length == 1)
            {
                continue;
            }

            if (moveingTo < 4)
            {

                if (PathType == PathTypes.linear)
                {
                    if (moveingTo <= 0)
                    {
                        movementDirection = 1;
                    }
                }
                moveingTo = moveingTo + movementDirection;
            }
            else
            {
                StartFEye = true;
            }
        }
    }
}
