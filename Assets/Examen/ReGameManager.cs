using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReGameManager : MonoBehaviour
{
    
    //poner arriba using UnityEngine.SceneManagement;
    public static ReGameManager Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
