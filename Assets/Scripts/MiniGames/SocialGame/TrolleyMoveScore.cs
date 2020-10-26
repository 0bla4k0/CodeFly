using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyMoveScore : MonoBehaviour
{
    bool MouseDown = false;

    void OnMouseDown()
    {
        MouseDown = true;
    }

    void OnMouseUp()
    {
        MouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Cursor = Input.mousePosition;
        Cursor = Camera.main.ScreenToWorldPoint(Cursor);
        if (MouseDown && Cursor.x < 830 && Cursor.x > 75 && Cursor.y > 35 && Cursor.y < 475)
        {
            this.transform.position = Cursor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "GoodSmileProblem":
                print(Random.Range(1, 10));
                break;
            default:
                print(collision.collider.tag);
                break;
        }
        Destroy(collision.collider.gameObject, 0.1f);
    }
}
