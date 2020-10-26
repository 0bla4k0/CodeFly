using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialProblemMove : MonoBehaviour
{

    int speed;

    void Start()
    {
        speed = Random.Range(250, 400);
    }

    void Update()
    {
        if (gameObject.transform.position.y <0)
            Destroy(gameObject);

        //int speed = Random.Range(StartSpeed, FinishSpeed);
        transform.Translate(0, -speed * Time.deltaTime, 0);
        
        
    }
}
