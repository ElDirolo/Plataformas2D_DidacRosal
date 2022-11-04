using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] hearts;
    public Text estrellaText;

    public GameObject HUD;
    public GameObject pantallaFinal;
    public GameObject personajeDerrota;
    public GameObject personajeVictoria;
    public GameObject Jugador;

    

    // Si ya hay una instancia que no soy yo me destruyo si hay mas de un game manager uno de ellos se mata
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
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
            DerrotaMenu();

        }
        if(Global.vidas == 1)
        {
            hearts[1].SetActive(false);

        }
        if(Global.vidas == 2)
        {
            hearts[2].SetActive(false);

        }
        if (Global.vidas == 3)
        {
            hearts[3].SetActive(false);

        }
        if (Global.vidas == 4)
        {
            hearts[4].SetActive(false);

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
            VictoriaMenu();
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
        if (Global.vidas > 3)
        {
            hearts[3].SetActive(true);

        }
        if (Global.vidas > 4)
        {
            hearts[4].SetActive(true);

        }
    }

    public void DerrotaMenu()
    {
        hearts[0].SetActive(false);
        HUD.SetActive(false);
        pantallaFinal.SetActive(true);
        personajeDerrota.SetActive(true);
        Jugador.SetActive(false);
        AudioManager.Instance.DerrotaSound();
    }
    
    public void VictoriaMenu()
    {
        HUD.SetActive(false);
        pantallaFinal.SetActive(true);
        personajeVictoria.SetActive(true);
        Jugador.SetActive(false);
        AudioManager.Instance.VictoriaSound();
    }
}
