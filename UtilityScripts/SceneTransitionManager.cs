using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(string Scene)
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }

    internal string GetScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
