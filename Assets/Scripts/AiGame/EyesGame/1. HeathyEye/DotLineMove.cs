﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotLineMove : MonoBehaviour // change script name
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private LineRenderer line;
    private Vector2 mousePos;
    public Material material;
    public GameObject StartBoxBlock;
    public GameObject SecondBoxBlock;
    public bool MouseDownArea;
    public static bool MouseDragStart;
    public static bool TaskCheckerConnectLine = false;

    void Start()
    {
        MouseDragStart = false;
        line = new GameObject("LineHealthy").AddComponent<LineRenderer>(); // change line name
        line.sortingLayerName = "Line";
        line.sortingOrder = 5;
        line.SetColors(Color.blue, Color.blue);
        line.material = material;
        line.positionCount = 2;
        line.startWidth = 5f;
        line.endWidth = 5f;
        line.useWorldSpace = true;
        line.numCapVertices = 2;
        line.generateLightingData = true;
    }

    void Update()
    {
        if (OneItemSlot.SetInRightBoxHealthyEye) // change
        {
            GetComponent<Image>().color = Color.blue;
            if (MouseDragStart)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(0, StartBoxBlock.transform.position);
                line.SetPosition(1, mousePos);

            }
            else if (Input.GetMouseButton(0) && line && MouseDragStart)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(1, mousePos);
            }
            else
            {
                if (MouseDragStart == false && FinishDotLine.ConnectLineEnter == false) // change
                {
                    line.SetPosition(0, StartBoxBlock.transform.position);
                    line.SetPosition(1, StartBoxBlock.transform.position);
                }
            }
        }
        else
        {
            GetComponent<Image>().color = new Color32(111, 111, 111, 255);
        }

        if (FinishDotLine.ConnectLineEnter) // change
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.SetPosition(1, SecondBoxBlock.transform.position);
            TaskCheckerConnectLine = true;
        }
    }

    void OnMouseDown()
    {
        MouseDownArea = true;
    }

    void OnMouseDrag()
    {
        if (MouseDownArea)
        {
            MouseDragStart = true;
        }
        else if (MouseDownArea == false)
        {
            MouseDragStart = false;
        }
    }

    void OnMouseUp()
    {
        MouseDownArea = false;
        MouseDragStart = false;
    }
}
