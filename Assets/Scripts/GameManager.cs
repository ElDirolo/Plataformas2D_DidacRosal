using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int vidas = 3;

    public int puntos = 0;

    // Si ya hay una instancia que no soy yo me destruyo si hay mas de un game manager uno de ellos se mata
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            {
                Instance = this;
            }
        }

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    public void Restavidas()
    {
        vidas--;
    }
}
