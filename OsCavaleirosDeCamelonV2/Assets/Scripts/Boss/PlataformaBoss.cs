using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaBoss : MonoBehaviour
{
    public static bool subir;
    [SerializeField] float limite;
    [SerializeField] float limite2;
    [SerializeField] float velocidade;
    [SerializeField] BoxCollider2D plataformaCollider;
    // Start is called before the first frame update
    void Start()
    {
        subir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(subir && transform.position.y < limite) {

            transform.Translate(Vector2.up * Time.deltaTime * velocidade);
            plataformaCollider.enabled = false;

        } else if(!subir && transform.position.y > limite2) {

            transform.Translate(Vector2.up * Time.deltaTime * -velocidade);
            plataformaCollider.enabled = false;

        } else {

            plataformaCollider.enabled = true;

        }
    }
}
