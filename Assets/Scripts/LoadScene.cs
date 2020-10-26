﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadScene_(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
