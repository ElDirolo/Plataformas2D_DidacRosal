using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] hearts;
    public Text estrellaText;
    

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
            hearts[0].SetActive(false);

        }
        if(Global.vidas == 1)
        {
            hearts[1].SetActive(false);

        }
        if(Global.vidas == 2)
        {
            hearts[2].SetActive(false);

        }        
    }

    public void EstellaRecogida()
    {
    
        AudioManager.Instance.EstellaSound();
        Global.puntos++;
        estrellaText.text = "" + Global.puntos; 
            
        if(Global.puntos == 13)
        {
            Debug.Log("vamos");

        }
        
    }

    public void CorazonRecogido()
    {
        Global.vidas++;
        AudioManager.Instance.VidaSound();
        

        if(Global.vidas > 1)
        {
            hearts[1].SetActive(true);

        }
        if(Global.vidas > 2)
        {
            hearts[2].SetActive(true);

        }
    }
}
