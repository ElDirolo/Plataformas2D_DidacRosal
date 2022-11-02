using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] hearts;
    

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





    public void Golpe()
    {
        Global.vidas--;
        AudioManager.Instance.GolpeSound();


        
        if(Global.vidas == 0)
        {
            Debug.Log("Dead");
            Destroy(hearts[0].gameObject);

        }
        if(Global.vidas == 1)
        {
            Destroy(hearts[1].gameObject);

        }
        if(Global.vidas == 2)
        {
            Destroy(hearts[2].gameObject);

        }        
    }

    public void EstellaRecogida()
    {
    
        AudioManager.Instance.EstellaSound();
        Global.puntos++;
            
        if(Global.puntos == 13)
        {
            Debug.Log("vamos");

        }
        
    }

    public void CorazonRecogido()
    {
        
    }
}
