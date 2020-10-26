using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialProblemSpawner : MonoBehaviour
{
    public GameObject[] ProblemImage;
    float StartStep, FinishStep;

    void Start()
    {
        StartStep = 0f;
        FinishStep = 170;
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            for(int j = 0; j < ProblemImage.Length; j++)
            {
                Vector2 position = new Vector2()
                {
                    x = Random.Range(StartStep, FinishStep),
                    y = Random.Range(515f, 630f)
                };
                GameObject spawn = Instantiate(ProblemImage[j], position, Quaternion.identity);
                spawn.GetComponent<SocialProblemMove>().enabled = true;
                StartStep += 150f;
                FinishStep += 150f;
            }

            StartStep = 0f;
            FinishStep = 170f;
            yield return new WaitForSeconds(2);
        }
    }
}
