using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barras : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool sobe;
    [SerializeField] float sobeLimiteMax;
    [SerializeField] float sobeLimiteMin;
    [SerializeField] float desceLimiteMax;
    [SerializeField] float desceLimiteMin;
    public static bool Cutscene_barra;
    // Start is called before the first frame update
    void Start()
    {
        Cutscene_barra = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!Cutscene_barra) {

            if(sobe) {

                if(transform.position.y < sobeLimiteMax) {

                    transform.Translate(Vector2.up * Time.deltaTime * speed);

                }

            }

            if(!sobe) {

                if(transform.position.y > desceLimiteMin) {
                    
                    transform.Translate(Vector2.down * Time.deltaTime * speed);

                }

            }

        } else 
        
        if (Cutscene_barra) {


            if(sobe) {

                if(transform.position.y > sobeLimiteMin) {

                    transform.Translate(Vector2.down * Time.deltaTime * speed);

                }

            }

            if(!sobe) {

                if(transform.position.y < desceLimiteMax) {
                    
                    transform.Translate(Vector2.up * Time.deltaTime * speed);

                }

            }

        }
        
        

    }
}
