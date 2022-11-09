using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    //[SerializeField]private float duration;
    //[SerializeField]private float magnitude;

    void Start() 
    {
        //llamar la funcion
        //Shake();
        //Llamar Corutina
        //StartCoroutine(Shake());    
    }


    public IEnumerator Shake(float duration, float magnitude)
    {
        //Espera x segundos
        //yield return new WaitForSeconds(1f);

        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;


            transform.position = new Vector3(x + originalPos.x, y +originalPos.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }

        /*for(float i = elapsed; i < duration; i += Time.deltaTime)
        {
            
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;


            transform.position = new Vector3(x + originalPos.x, y +originalPos.y, transform.position.z);
            yield return 0;
        }

        do
        {
            Debug.Log("shake");
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;


            transform.position = new Vector3(x + originalPos.x, y +originalPos.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;

        }while(elapsed < duration);

        //Para el tema del contador de las vidas pero no es el completo ya que se tiene que mirar como hacerlo
        GameObject[] vidas;

        foreach (GameObject vida in vidas)
        {
            vida.SetActive(false)
        }*/
    }

}
