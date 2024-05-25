using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPower : MonoBehaviour
{
    
    [SerializeField] float velocidadePoder;
    [SerializeField] Rigidbody2D poderRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.y == 0) {

            //print("rotacao = 0");
            poderRb.velocity = new Vector2(velocidadePoder, poderRb.velocity.y);

        } else if(transform.rotation.y != 0) {

            //print("rotacao = 180");
            poderRb.velocity = new Vector2(-velocidadePoder, poderRb.velocity.y);

        }
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag == "Ground") {

            Destroy(this.gameObject);

        }

    }

}
