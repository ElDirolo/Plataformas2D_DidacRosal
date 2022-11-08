using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerMove player;

    void Awake()
    {  
        player = GameObject.Find("Jugador").GetComponent<PlayerMove>();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        player.isGrounded = true;
        player.anim.SetBool("Salto", false);
        
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
       player.isGrounded = false;
    }
}
