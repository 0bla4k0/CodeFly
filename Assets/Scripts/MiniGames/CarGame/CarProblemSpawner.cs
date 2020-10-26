using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarProblemSpawner : MonoBehaviour
{
    public GameObject CarProblem;
    public GameObject CarProblem2;
    public GameObject CarProblem3;

    void Start()
    {
        StartCoroutine(Spawner());
    }


    IEnumerator Spawner() 
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            float rand = Random.Range(120f, 410f);

            if (rand - 260 > 120)
            {
                GameObject extraProblem2 = Instantiate(CarProblem3, new Vector2(950, rand - 50), Quaternion.identity);
                Destroy(extraProblem2, 3);
            }

            else if (rand + 260 < 410)
            {
                GameObject extraProblem = Instantiate(CarProblem2, new Vector2(950, rand + 10), Quaternion.identity);
                Destroy(extraProblem, 3);
            }

            else
            {
                GameObject newProblem = Instantiate(CarProblem, new Vector2(920, rand), Quaternion.identity);
                Destroy(newProblem, 3);
            }
        }

    }
}
