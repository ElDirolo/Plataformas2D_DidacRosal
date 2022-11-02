using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombas : MonoBehaviour
{

    Animator bombaAnimator;

    BoxCollider2D bombaCollider;

    private void Awake()
    {
        bombaAnimator = GetComponent<Animator>();
        bombaCollider = GetComponent<BoxCollider2D>();
    }

    public void DeathBoom()
    {


        bombaCollider.enabled = false;
        bombaAnimator.SetBool("Explosion", true);
        Destroy(this.gameObject, 0.8f);

    }

}
