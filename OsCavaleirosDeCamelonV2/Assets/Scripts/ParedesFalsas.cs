using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParedesFalsas : MonoBehaviour
{
    
    [SerializeField] Tilemap paredeRend;
    [SerializeField] float fadeVl;
    [SerializeField] float fadeDestino;
    [SerializeField] bool isFadding;

    void Update()
    {
        
        paredeRend.color = new Color(1f, 1f, 1f, fadeVl);

        if(isFadding == true && fadeVl > fadeDestino) {

            fadeVl -= Time.deltaTime * 2;

        }

        if(isFadding == false && fadeVl < 1) {

            fadeVl += Time.deltaTime * 2;

        }

        if(fadeVl > 1) {

            fadeVl = 1;

        }

        if(fadeVl < fadeDestino) {

            fadeVl = fadeDestino;

        }

    }

    public void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player") {

            isFadding = true;

        }        

    }

    public void OnTriggerExit2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player") {

            isFadding = false;

        }

    }
}
