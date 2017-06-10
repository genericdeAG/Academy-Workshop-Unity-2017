﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public SceneAsset[] Scenes;

    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene(Scenes[0].name, LoadSceneMode.Additive);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
