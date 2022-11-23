using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBro : MonoBehaviour
{
    #region player
    private Rigidbody2D rBody;

    private float horizontal;

    [SerializeField]private float speed = 3;



    [SerializeField]private float jumpForce = 10;

    [SerializeField]bool isGrounded;

    [SerializeField]Transform groundSensor;

    [SerializeField]float sensorRadius;

    [SerializeField]LayerMask sensorLayer;


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

        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, sensorLayer);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundSensor.position, sensorRadius);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 9)
        {
            anim.SetBool("isJumping",false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Star")
        {
            ManagerBro.Instance.LoadLevel(4);
        }
        else if(other.gameObject.tag == "Coin")
        {
            ManagerBro.Instance.AddCoin(other.gameObject);
        }
    }
    #endregion
}
