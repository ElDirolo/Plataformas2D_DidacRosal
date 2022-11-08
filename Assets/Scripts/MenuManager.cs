using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject title;
    public GameObject mainButtons;
    public GameObject optionsMenu;
    public GameObject selectorMenu;
    public GameObject marcosPersonajes;

    public void OpenOptions()
    {
        title.SetActive(false);
        mainButtons.SetActive(false);
        optionsMenu.SetActive(true);
    }


    public void OpenSelector()
    {
        title.SetActive(false);
        mainButtons.SetActive(false);
        selectorMenu.SetActive(true);
        marcosPersonajes.SetActive(true);
    }

    public void Scene()
    {
        SceneManager.LoadScene("Platforms");
    }

    public void LoadNivel()
    {
        Invoke("Scene", 1f);
    }







    public void Scene2()
    {
        SceneManager.LoadScene("Platforms 1");
    }

    public void LoadNivel2()
    {
        Invoke("Scene2", 1f);
    }





    public void Scene3()
    {
        SceneManager.LoadScene("Platforms 2");
    }

    public void LoadNivel3()
    {
        Invoke("Scene3", 1f);
    }
}
