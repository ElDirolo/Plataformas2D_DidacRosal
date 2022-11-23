using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repaso_Player : MonoBehaviour
{
    private Rigidbody2D rBody;

    private float horizontal;

    [SerializeField]private float speed = 3;



    //ahora haremos el salto para ello necesitaremos una fuerza,el sensor,el diametro del sensor,lo que va detectar el sensor y un bool para que nos diga si estamos o no en el suelo

    [SerializeField]private float jumpForce = 10;

    [SerializeField]bool isGrounded;

    [SerializeField]Transform groundSensor;

    [SerializeField]float sensorRadius;

    [SerializeField]LayerMask sensorLayer;

    //para las animaciones
    private Animator anim;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
       
        //Para que rote el personaje        
        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            anim.SetBool("isRunning",true);
        }

        else if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            anim.SetBool("isRunning",true); 
        }
        
        else if(horizontal == 0)
        {
            anim.SetBool("isRunning",false); 
        }

        //para el salto.Lo que hace es hacer un circulo que servira para detectar el suelo,crearemos un objeto y le pondremos los parametros.Dentro del if pondremos la fuerza que ara el salto.
        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, sensorLayer);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
        }
    }

    void OnDrawGizmos()
    {
        //lo que hemos esto es ver el radio del detector del suelo.Pondremos primero la posicion dende queremos el este(groundsensor) y despues el radio que queremos(SensorRadius)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundSensor.position, sensorRadius);
    }

    //srive para detectar colliders y para que la condicion de saltp sea falso
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 9)
        {
            anim.SetBool("isJumping",false);
        }
    }

    //para detectar las estrella
    void OnTriggerEnter2D(Collider2D other)
    {

        //lo del loadScene el numero indica cual escena queremos que active en este caso el 4
        if(other.gameObject.tag == "Star")
        {
            ReGameManager.Instance.LoadLevel(4);
        }

        else if(other.gameObject.tag == "Coin")
        {
            ReGameManager.Instance.AddCoin(other.gameObject);
        }
    }



}
