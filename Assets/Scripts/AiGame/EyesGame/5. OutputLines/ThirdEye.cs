using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdEye : MonoBehaviour  // change script name
{
    public static bool ConnectLineEnter = false;
    public static bool HealthyBlock = false;
    public static bool TaskChekerConnect = false;

    private LineRenderer line;
    private Vector2 mousePos;
    public Material material;
    public GameObject StartBoxBlock;
    public GameObject SecondBoxBlock;
    public bool MouseDownArea;
    public static bool MouseDragStart;

    void Start()
    {
        MouseDragStart = false;
        line = new GameObject("LineOutThird").AddComponent<LineRenderer>(); // change line name
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
        if (ThirdItemSlot.SetInRightBoxThirdEye) // change
        {
            GetComponent<Image>().color = Color.cyan;
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
                if (MouseDragStart == false && OutputBlock.TConnectLineEnter == false) // change
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

        if (OutputBlock.TConnectLineEnter) // change
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.SetPosition(1, SecondBoxBlock.transform.position);
            TaskChekerConnect = true;
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
