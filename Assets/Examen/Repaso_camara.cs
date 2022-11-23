using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repaso_camara : MonoBehaviour
{

    /*
    //con solo esta ya tendremos que se mueva.
    [SerializeField]private Transform cameraTarget;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, -10);
    }
    */



    [SerializeField]private Transform cameraTarget;
    [SerializeField]private Vector3 offset;

    //esto es para suavizar el movimiento de la camara
    [SerializeField]float smoothTime;
    Vector2 velocity;

    //Para los limites de la camara
    [SerializeField]Vector2 minPos;
    [SerializeField]Vector2 maxPos;
 
    void FixedUpdate()
    {
        /*
        para colocar la camara como queremos
        Vector3 desiredPos = new Vector3(cameraTarget.position.x + offset.x, cameraTarget.position.y + offset.y, offset.z);
        transform.position = new Vector3(desiredPos.x, desiredPos.y, desiredPos.z);
        */
        //con suavides y limites
        Vector3 desiredPos = new Vector3(cameraTarget.position.x + offset.x, cameraTarget.position.y + offset.y, offset.z);

        float posX = Mathf.SmoothDamp(transform.position.x, desiredPos.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, desiredPos.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(Mathf.Clamp(posX, minPos.x, maxPos.x), Mathf.Clamp(posY, minPos.y, maxPos.y), desiredPos.z);  
     

    }
}
