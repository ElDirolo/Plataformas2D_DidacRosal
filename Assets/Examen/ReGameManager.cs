using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReGameManager : MonoBehaviour
{
    
    //poner arriba using UnityEngine.SceneManagement; y el using UnityEngine.UI;
    public static ReGameManager Instance;

    //Contador de monedas
    int coins = 0;

    [SerializeField]Text coinText;

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


    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void AddCoin(GameObject moneda)
    {
        coins++;
        coinText.text = coins.ToString();
        Destroy(moneda);

    }
}
