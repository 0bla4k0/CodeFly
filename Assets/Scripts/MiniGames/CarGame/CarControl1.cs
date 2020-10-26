using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarControl1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public static int tmp = 0;
    double temp = 2.4;
    public GameObject RestartMenu;

    void Start()
    {
        Time.timeScale = 1f;
        RestartMenu.SetActive(false);
        rb = GetComponent <Rigidbody2D>();
    }

    void Update()
    {
        if (tmp == 0)
        {
            Time.timeScale = 0f;
            RestartMenu.SetActive(true);
            tmp++;
        }

        Vector2 moveInput = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        moveVelocity = moveInput * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D (Collision2D  collision)
    {
        if (collision.collider.tag == "problem")
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
            RestartMenu.SetActive(true);
        }

    }
}
