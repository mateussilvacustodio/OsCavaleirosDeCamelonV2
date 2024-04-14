using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{    
    [SerializeField] bool podeAbrir;
    [SerializeField] Animator bauAnim;
    [SerializeField] Rigidbody2D QuantMoedas2;
    [SerializeField] Rigidbody2D QuantMoedas;
    [SerializeField] MeshRenderer QuantMoedasRd;
    [SerializeField] Dinheiro dinheiro;
    
    void Update()
    {

        if(podeAbrir == true && Input.GetButtonDown("Fire2")) {

            bauAnim.SetBool("IsOpen", true);
            podeAbrir = false;
            StartCoroutine(dinheiro.LerparValor(5));
            QuantMoedas2.velocity = new Vector2(0, 2.5f);
            Destroy(QuantMoedas2.gameObject, 0.6f);
            QuantMoedasRd.enabled = true;
            QuantMoedas.velocity = new Vector2(0, 2.5f);
            Destroy(QuantMoedas.gameObject, 0.6f);

        }

    }

    public void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player" && bauAnim.GetBool("IsOpen") == false) {

            podeAbrir = true;

        }

    }

    public void OnTriggerExit2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player") {

            podeAbrir = false;

        }

    }
}
