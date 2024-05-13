using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Flecha : MonoBehaviour
{
    [SerializeField] Rigidbody2D flechaRb;
    //[SerializeField] SpriteRenderer flechaSp;
    [SerializeField] Transform flechaT;
    [SerializeField] float velocidadeFlecha;
    [SerializeField] BoxCollider2D flechaCollider;
    [SerializeField] bool cair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flechaT.rotation.y == 0 && !cair) {

            //print("rotacao = 0");
            flechaRb.velocity = new Vector2(-velocidadeFlecha, flechaRb.velocity.y);

        } else if(flechaT.rotation.y != 0 && !cair) {

            //print("rotacao = 180");
            flechaRb.velocity = new Vector2(velocidadeFlecha, flechaRb.velocity.y);

        } else if (cair) {

            flechaRb.velocity = new Vector2(0, flechaRb.velocity.y);

        }
    }

    void OnTriggerEnter2D (Collider2D collider) {

        if(collider.gameObject.name == "Arma") {

            print("caia flecha");
            cair = true;
            flechaCollider.enabled = false;
            flechaRb.gravityScale = 1;
            

        }

    }
}
