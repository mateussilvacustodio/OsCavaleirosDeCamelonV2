using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] bool podeAbrir;
    [SerializeField] Animator bauAnim;
    [SerializeField] Rigidbody2D QuantMoedas2;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(podeAbrir == true && Input.GetButtonDown("Fire2")) {

            bauAnim.SetBool("IsOpen", true);
            podeAbrir = false;
            QuantMoedas2.velocity = new Vector2(0, 2.5f);
            Destroy(QuantMoedas2.gameObject, 0.6f);

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
